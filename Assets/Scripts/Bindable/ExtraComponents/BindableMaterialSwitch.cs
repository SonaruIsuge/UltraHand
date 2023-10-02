using System;
using UnityEngine;

namespace Bind
{
    [RequireComponent(typeof(Renderer), typeof(Bindable))]
    public class BindableMaterialSwitch : MonoBehaviour, IBindablePickDropSwitch, IBindableSelectSwitch
    {
        [SerializeField] private Material selectMat;
        [SerializeField] private Material unselectMat;
        [SerializeField] private Material pickUpMat;

        private Bindable bindableItem;
        private Renderer itemRenderer;
        

        private void Awake()
        {
            itemRenderer = GetComponent<Renderer>();
            bindableItem = GetComponent<Bindable>();
        }

        private void OnEnable()
        {
            bindableItem.OnItemSelect += Select;
            bindableItem.OnItemDeselect += Unselect;
            bindableItem.OnItemPicked += PickUp;
            bindableItem.OnItemDropped += DropDown;
        }

        private void OnDisable()
        {
            bindableItem.OnItemSelect -= Select;
            bindableItem.OnItemDeselect -= Unselect;
            bindableItem.OnItemPicked -= PickUp;
            bindableItem.OnItemDropped -= DropDown;
        }

        public void Select()
        {
            itemRenderer.material = selectMat;
        }

        public void Unselect()
        {
            itemRenderer.material = unselectMat;
        }

        public void PickUp()
        {
            itemRenderer.material = pickUpMat;
        }

        public void DropDown()
        {
            itemRenderer.material = unselectMat;
        }
    }
}