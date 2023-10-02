using Bind;
using MyEvent;
using UnityEngine;

namespace Player
{
    public class DetectState : IUltraHandState
    {
        private readonly IInput playerInput;
        private readonly PlayerUltraHand ultraHand;
        private UltraHandAttr attr;
        private UltraHandProps props;
        
        private IRayProvider rayProvider;
        private IRayDetector<Bindable> detector;
        
        
        public DetectState(PlayerUltraHand ultraHand, IInput input)
        {
            playerInput = input;
            this.ultraHand = ultraHand;
            attr = this.ultraHand.Attr;
            props = this.ultraHand.Props;

            rayProvider = new CameraForwardRayProvider(ultraHand.Player.PlayerCam);
            detector = new BindableDetector();
            
            EventManager.Register<OnUltraHandDisable>(DisableUltraHandCallback);
        }


        ~DetectState()
        {
            EventManager.Unregister<OnUltraHandDisable>(DisableUltraHandCallback);
        }
        
        
        public void Enter()
        {
            EventManager.RaiseEvent<OnUltraHandEnable>(null);
        }
        

        public void Stay()
        {
            var ray = rayProvider.CreateRay();
            if (!detector.TryDetectItem(ray, attr.DetectRange, attr.DetectLayer))
            {
                ResetDetectData();
            }
            else
            {
                UpdateDetectItem();
            }
            

            if (detector.DetectItem != null && playerInput.ChooseItem)
            {
                ultraHand.ChangeState(UltraHandStateEnum.Select);
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
            
        }


        private void DisableUltraHandCallback(OnUltraHandDisable e)
        {
            ResetDetectData();
        }


        private void ResetDetectData()
        {
            props.DetectItem?.Unselect();
            props.DetectItem = null;
            EventManager.RaiseEvent<OnResetHitItem>(null);
        }


        private void UpdateDetectItem()
        {
            if(props.DetectItem != detector.DetectItem) props.DetectItem?.Unselect();
            
            props.DetectItem = detector.DetectItem;
            props.HitInfo = detector.HitInfo;
            props.CloseBindPosIndex = GetCloseBindLocalPosIndex();
            props.DetectItem?.Select();
            
            EventManager.RaiseEvent<OnHitBindableItem>(new OnHitBindableItem(props.DetectItem, props.HitInfo, props.CloseBindPosIndex));
        }


        private int GetCloseBindLocalPosIndex()
        {
            var hitLocalPoint = props.DetectItem.transform.InverseTransformPoint(props.HitInfo.point);
            var closest = Mathf.Infinity;
            var closestIndex = -1;
            for (var i = 0; i < props.DetectItem.BindLocalPositions.Length; i++)
            {
                var distance = Vector3.Distance(hitLocalPoint, props.DetectItem.BindLocalPositions[i]);
                if (!(distance <= closest)) continue;
            
                closest = distance;
                closestIndex = i;
            }

            return closestIndex;
        }
    }
}