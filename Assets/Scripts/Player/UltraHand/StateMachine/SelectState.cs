using Bind;
using MyEvent;
using Unity.Mathematics;
using UnityEngine;

namespace Player
{
    public class SelectState : IUltraHandState
    {
        private IInput playerInput;
        private PlayerUltraHand ultraHand;
        private Camera playerCam;
        private UltraHandAttr attr;
        private UltraHandProps props;
        
        private bool canBind;
        
        private ClosestBindFilter closeBindFilter;
        private Transform PlayerTrans => ultraHand.Player.transform;
        
        
        public SelectState(PlayerUltraHand ultraHand, IInput input)
        {
            this.ultraHand = ultraHand;
            playerCam = ultraHand.Player.PlayerCam;
            playerInput = input;
            attr = this.ultraHand.Attr;
            props = this.ultraHand.Props;

            closeBindFilter = new ClosestBindFilter(attr);
            
            EventManager.Register<OnCatchItem>(OnCatchItemCallback);
            EventManager.Register<OnBindItem>(OnBindItemCallback);
            EventManager.Register<OnUnBindFromRoot>(OnUnbindItemCallback);
        }


        ~SelectState()
        {
            EventManager.Unregister<OnCatchItem>(OnCatchItemCallback);
            EventManager.Unregister<OnBindItem>(OnBindItemCallback);
            EventManager.Unregister<OnUnBindFromRoot>(OnUnbindItemCallback);
        }
        
        
        public void Enter()
        {
            EventManager.RaiseEvent<OnCatchItem>(new OnCatchItem(props.DetectItem, props.HitInfo, props.CloseBindPosIndex));
        }
        

        public void Stay()
        {
            UpdateMove(playerInput.AdjustDistance, playerInput.AdjustRotation);
            UpdateDetectBind();

            if (canBind && playerInput.ChooseItem)
            {
                Bind();
            }

            else if (playerInput.Unbind)
            {
                Unbind();
            }

            if (playerInput.CancelChoose)
            {
                ultraHand.ChangeState(UltraHandStateEnum.Detect);
                return;
            }

            if (playerInput.UltraHand)
            {
                ultraHand.ChangeState(UltraHandStateEnum.Inactive);
                return;
            }
        }

        public void Exit()
        {
            EventManager.RaiseEvent<OnDropItem>(new OnDropItem(props.SelectItem));
            ClearSelectData();
            ClearBindData();
        }
        
        
        private void OnCatchItemCallback(OnCatchItem e)
        {
            if(!e.Bindable) return;
            
            SetSelectItem(e.Bindable);
            CalcMoveData(e.Bindable, e.HitLocalPoint, e.HitItemPosIndex);
        }


        private void OnBindItemCallback(OnBindItem e)
        {
            if(e.Self is not SameRootBindItem item || !item.root ) return;
            
            RecordSelectedValue(item.RootTransform);
        }


        private void OnUnbindItemCallback(OnUnBindFromRoot e)
        {
            if(e.Self is not SameRootBindItem item) return;
            
            RecordSelectedValue(item.RootTransform);
        }


        private void SetSelectItem(Bindable item)
        {
            props.SelectItem = item;
            item.PickUp();
        }
        
        
        private void CalcMoveData(Bindable item, Vector3 point, int itemBindIndex)
        {
            props.HitPoint = point;
            props.CloseBindPosIndex = itemBindIndex;

            RecordSelectedValue(item.RootTransform);
        }


        private void RecordSelectedValue(Transform itemTrans)
        {
            props.PlayerHitPointVec = itemTrans.TransformPoint(props.HitPoint) - PlayerTrans.position;
            props.HitPointCenterDrift = itemTrans.position - itemTrans.TransformPoint(props.HitPoint);
            props.SelectedScreenPos = playerCam.WorldToScreenPoint(itemTrans.position);
            
            props.OffsetPlayerRotate = Quaternion.Inverse(PlayerTrans.rotation);
            props.SelectedItemRotate = itemTrans.rotation;
            props.PlayerRelateRotation = props.OffsetPlayerRotate * itemTrans.rotation;
        }
        
        
        private void UpdateMove(float moveInput, Vector2 rotateInput)
        {
            // input affect position
            var unitVec = props.PlayerHitPointVec.normalized;
            var distance = props.PlayerHitPointVec.magnitude;
            distance = Mathf.Clamp(distance + moveInput * attr.ItemMoveSpeed * Time.deltaTime, attr.PlayerCloseRange,
                attr.PlayerFarRange);
            props.PlayerHitPointVec = unitVec * distance;

            // input affect rotation
            if (rotateInput.x != 0)
                props.SelectedItemRotate = Quaternion.Euler(0, attr.ItemRotateAngle * -rotateInput.x, 0) * props.SelectedItemRotate;
            
            if (rotateInput.y != 0)
                props.SelectedItemRotate = Quaternion.AngleAxis(attr.ItemRotateAngle * rotateInput.y, PlayerTrans.right) * props.SelectedItemRotate;
            
            // calculate current position and rotation of item
            var pos = PlayerTrans.position + (PlayerTrans.rotation * props.OffsetPlayerRotate) * (props.PlayerHitPointVec + props.HitPointCenterDrift);
            pos.y = playerCam.ScreenToWorldPoint(props.SelectedScreenPos).y;
            
            // player current rotation * inverse player rotation * item rotation * (inverse item rotation * world rotation) * item rotation
            var rot = PlayerTrans.rotation * props.OffsetPlayerRotate * props.SelectedItemRotate;

            props.SelectItem.UpdateMove(pos, rot);
        }


        private void ClearSelectData()
        {
            if(props.SelectItem) props.SelectItem.DropDown();
            props.SelectItem = null;

            props.PlayerHitPointVec = Vector3.zero;
            props.HitPointCenterDrift = Vector3.zero;
            props.SelectedScreenPos = Vector3.zero;
            props.OffsetPlayerRotate = Quaternion.identity;
            props.PlayerRelateRotation = Quaternion.identity;
        }
        
        
        private void UpdateDetectBind()
        {
            if(!props.SelectItem) return;

            if (closeBindFilter.TryGetClosestBindable(props.SelectItem, out var closeItem))
            {
                props.ClosestItem = closeItem;
                canBind = true;
                EventManager.RaiseEvent<OnDetectOtherBind>(
                    new OnDetectOtherBind(props.SelectItem, props.ClosestItem, closeBindFilter.SelfPoint,
                        closeBindFilter.OtherPoint));
            }
            else
            {
                canBind = false;
                EventManager.RaiseEvent<OnResetDetectOtherBind>(null);
            }
        }


        private void Bind()
        {
            if(!props.SelectItem || !props.ClosestItem) return;

            var otherSelfVector = closeBindFilter.SelfPoint - closeBindFilter.OtherPoint;
            var selfOtherDistance = closeBindFilter.Distance;
            var moveVector = otherSelfVector.normalized * (selfOtherDistance - attr.BindRange);
            
            props.ClosestItem.RootTransform.Translate(moveVector, Space.World);
            props.SelectItem.Bind(props.ClosestItem);
        }


        private void Unbind()
        {
            if(!props.SelectItem) return;
            
            props.SelectItem.Unbind();
        }
        
        
        private void ClearBindData()
        {
            props.SelectItem = null;
            props.ClosestItem = null;
            closeBindFilter.ClearData();
            EventManager.RaiseEvent<OnResetDetectOtherBind>(null);
        }
    }
}