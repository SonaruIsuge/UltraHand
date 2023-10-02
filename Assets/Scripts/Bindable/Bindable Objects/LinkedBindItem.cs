using System;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Bind
{
    public class LinkedBindItem : Bindable
    {
        public LinkedBindItem bindParent;
        public LinkedBindItem bindChild;


        public override void Select()
        {
            if(bindParent)
            { 
                FirstBindable().Select();
                return;
            }

            var current = this;
            while (current)
            {
                current.ImplementSelect();
                current = current.bindChild;
            }
        }


        private void ImplementSelect()
        {
            base.Select();
        }
        

        public override void Unselect()
        {
            if(bindParent)
            { 
                FirstBindable().Unselect();
                return;
            }

            var current = this;
            while (current)
            {
                current.ImplementUnselect();
                current = current.bindChild;
            }
        }


        private void ImplementUnselect()
        {
            base.Unselect();
        }

        
        public override void PickUp()
        {
            base.PickUp();

            FirstBindable().Rb.useGravity = false;
            FirstBindable().Rb.velocity = Vector3.zero;
            FirstBindable().Rb.angularVelocity = Vector3.zero;
        }


        public override void DropDown()
        {
            base.DropDown();
            
            FirstBindable().Rb.useGravity = true;
            FirstBindable().Rb.velocity = Vector3.zero;
            FirstBindable().Rb.angularVelocity = Vector3.zero;
        }


        public override void Bind(Bindable other)
        {
            if(other is not LinkedBindItem item) return;
            
            base.Bind(other);
            
            // Create bind link
            bindChild = item;
            item.bindParent = this;
            
            // Calculate rotate and scale when set parent
            var rotate = item.transform.rotation;
            var scale = item.transform.lossyScale;
            
            item.transform.SetParent(transform);
            item.transform.rotation = rotate;
            item.transform.localScale = Vector3.Scale(scale, transform.lossyScale.Invert());
            
            Destroy(other.Rb);
        }


        public override void Unbind()
        {
            base.Unbind();
        }


        public override void UpdateMove(Vector3 pos, Quaternion rot)
        {
            transform.position = pos;
            transform.rotation = rot;
        }


        public LinkedBindItem FirstBindable()
        {
            var bindLastItem = bindParent;
            return bindLastItem == null ? this : bindLastItem.FirstBindable();
        }


        public LinkedBindItem LastBindable()
        {
            var bindNextItem = bindChild;
            return bindNextItem == null ? this : bindNextItem.LastBindable();
        }
    }
}