
using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Bind
{
    public class Bindable : MonoBehaviour
    {
        // properties
        [SerializeField] private Vector3[] bindLocalPositions;
        //[SerializeField] private float detectOtherRange;
        
        // References
        public Collider Col { get; protected set; }
        public Rigidbody Rb { get; protected set; }

        public virtual Transform RootTransform => transform;
        public Vector3[] BindLocalPositions => bindLocalPositions;
        public float DetectOtherRange => CalculateDetectRange();
        
        
        public Action OnItemSelect;
        public Action OnItemDeselect;
        public Action OnItemPicked;
        public Action OnItemDropped;
        public Action<Bindable> OnItemBind;
        public Action OnItemUnbind;

        public Action DrawGizmosEvent;


        private void Awake()
        {
            Col = GetComponent<Collider>();
            Rb = GetComponent<Rigidbody>();

            Init();
        }
        
        
        private void OnDrawGizmosSelected()
        {
            DrawBindPositions();
            
            DrawGizmosEvent?.Invoke();
        }
        
        
        protected virtual void Init(){ }


        public virtual void Select()
        {
            OnItemSelect?.Invoke();
        }

        
        public virtual void Unselect()
        {
            OnItemDeselect?.Invoke();
        }

        
        public virtual void PickUp()
        {
            OnItemPicked?.Invoke();
        }

        
        public virtual void DropDown()
        {
            OnItemDropped?.Invoke();
        }

        
        public virtual void Bind(Bindable other)
        {
            OnItemBind?.Invoke(other);
        }
        

        public virtual void Unbind()
        {
            OnItemUnbind?.Invoke();
        }
        
        
        public virtual void UpdateMove(Vector3 pos, Quaternion rot) { }

        public virtual bool IsBindTogether(Bindable other)
        {
            return false;
        }


        private float CalculateDetectRange()
        {
            var size = Col.bounds.size;
            var max = Mathf.Max(size.x, size.y, size.z);
            return max;
        }
        
        
        private void DrawBindPositions()
        {
            if(bindLocalPositions.Length == 0) return;
            
            Gizmos.color = Color.red;
            foreach (var pos in bindLocalPositions)
            {
                var worldPos = transform.TransformPoint(pos);
                Gizmos.DrawSphere(worldPos, .1f);
            }
        }

    }
}