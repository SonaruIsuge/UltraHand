using System.Collections.Generic;
using MyEvent;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace Bind
{
    public class SameRootBindItem : Bindable
    {
        public BindRoot root;
        public override Transform RootTransform => root ? root.transform : transform;
        

        public override void Select()
        {
            if (root)
                foreach (var item in root.AllBindItem) item.ImplementSelect();
            else
                ImplementSelect();
        }
        

        public override void Unselect()
        {
            if (root)
                foreach (var item in root.AllBindItem) item.ImplementUnselect();
            else 
                base.Unselect();
        }
        

        public override void PickUp()
        {
            if (root)
                foreach (var item in root.AllBindItem) item.ImplementPickUp();
            else 
                ImplementPickUp();
        }


        public override void DropDown()
        {
            if(root)
                foreach (var item in root.AllBindItem) item.ImplementDropDown();
            else
                ImplementDropDown();
        }


        private void ImplementSelect()
        {
            base.Select();
        }


        private void ImplementUnselect()
        {
            base.Unselect();
        }
        

        private void ImplementPickUp()
        {
            base.PickUp();
            
            var rootRb = root ? root.Rb : Rb;
            rootRb.useGravity = false;
            rootRb.velocity = Vector3.zero;
            rootRb.angularVelocity = Vector3.zero;
        }


        private void ImplementDropDown()
        {
            base.DropDown();
            
            var rootRb = root ? root.Rb : Rb;
            rootRb.useGravity = true;
            rootRb.velocity = Vector3.zero;
            rootRb.angularVelocity = Vector3.zero;
        }
        
        
        public override void Bind(Bindable other)
        {
            if(other is not SameRootBindItem item) return;
            
            base.Bind(item);

            BindRoot targetRoot;
            if (root) targetRoot = root;
            else if (item.root) targetRoot = item.root;
            else
            {
                targetRoot = new GameObject("Root").AddComponent<BindRoot>();
                targetRoot.transform.position = (transform.position + item.transform.position) / 2;
                targetRoot.transform.rotation = quaternion.identity;
            }
            
            targetRoot.Init();
            
            // Handle this bind
            root = targetRoot;
            root.AddBindItem(this);
            transform.SetParent(root.transform, true);
            if(Rb) Destroy(Rb);

            // Handle item bind
            if (item.root && item.root != targetRoot)
            {
                var deletedRoot = item.root;
                foreach (var binded in item.root.AllBindItem)
                {
                    binded.transform.SetParent(targetRoot.transform, true);
                    targetRoot.AddBindItem(binded);
                    //deletedRoot.RemoveBindItem(binded);
                    binded.root = targetRoot;
                }
                Destroy(deletedRoot.gameObject);
            }
            else
            {
                item.transform.SetParent(targetRoot.transform, true);
                targetRoot.AddBindItem(item);
                item.root = targetRoot;
                if(item.Rb) Destroy(item.Rb);
            }
            
            item.PickUp();
            EventManager.RaiseEvent<OnBindItem>(new OnBindItem(this, other));
        }


        public override void Unbind()
        {
            if(!root) return;

            base.Unbind();
            
            root.RemoveBindItem(this);
            
            transform.SetParent(null);
            Rb = transform.AddComponent<Rigidbody>();
            
            root.AllBindItem[0].DropDown();
            root = null;
            
            PickUp();

            EventManager.RaiseEvent<OnUnBindFromRoot>(new OnUnBindFromRoot(this));
        }


        public override void UpdateMove(Vector3 pos, Quaternion rot)
        {
            var trans = root ? root.transform : transform;
            trans.position = pos;
            trans.rotation = rot;
        }


        public override bool IsBindTogether(Bindable other)
        {
            if (other is not SameRootBindItem otherSameRootItem) return true;

            return root && root.ContainBindable(otherSameRootItem);
        }
    }


    public class BindRoot : MonoBehaviour
    {
        private Rigidbody rb;
        private List<SameRootBindItem> allBindItem;

        public Rigidbody Rb => rb;
        public List<SameRootBindItem> AllBindItem => allBindItem;
        public int ItemCount => allBindItem.Count;


        public void Init()
        {
            if (!rb) rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = true;
            transform.localScale = Vector3.one;
        }


        public void AddBindItem(SameRootBindItem newItem)
        {
            allBindItem ??= new List<SameRootBindItem>();
            if(allBindItem.Contains(newItem)) return;
            
            allBindItem.Add(newItem);
        }


        public void RemoveBindItem(SameRootBindItem item)
        {
            if(!allBindItem.Contains(item)) return;

            allBindItem.Remove(item);
        }


        public bool ContainBindable(SameRootBindItem item) => allBindItem.Contains(item);
    }
}