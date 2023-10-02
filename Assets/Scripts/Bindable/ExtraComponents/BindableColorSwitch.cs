using Unity.VisualScripting;
using UnityEngine;

namespace Bind
{
    [RequireComponent(typeof(Renderer), typeof(Bindable))]
    public class BindableColorSwitch : MonoBehaviour, IBindablePickDropSwitch, IBindableSelectSwitch
    {
        [SerializeField] private string materialValueName;
        [SerializeField, ColorUsage(true, true)] private Color selectColor;
        [SerializeField, ColorUsage(true, true)] private Color pickUpColor;

        private Color originColor;
        private Bindable bindableItem;
        private Renderer itemRenderer;
        private Material material;

        private void Awake()
        {
            itemRenderer = GetComponent<Renderer>();
            bindableItem = GetComponent<Bindable>();
            material = itemRenderer.material;
            originColor = material.GetColor(materialValueName);
            material.EnableKeyword("_EMISSION");
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
            material.SetColor(materialValueName, selectColor);
        }

        public void Unselect()
        {
            material.SetColor(materialValueName, originColor);
        }

        public void PickUp()
        {
            material.SetColor(materialValueName, pickUpColor);
        }

        public void DropDown()
        {
            material.SetColor(materialValueName, originColor);
        }
    }
}