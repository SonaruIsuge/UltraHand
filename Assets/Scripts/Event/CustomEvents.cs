using Bind;
using UnityEngine;

namespace MyEvent
{
    public class OnUltraHandEnable : CustomEvent { }
    
    public class OnUltraHandDisable : CustomEvent { }

    public class OnHitBindableItem : CustomEvent
    {
        public Bindable Bindable;
        public RaycastHit HitInfo;
        public int HitItemPosIndex;

        public OnHitBindableItem(Bindable item, RaycastHit hit, int index)
        {
            Bindable = item;
            HitInfo = hit;
            HitItemPosIndex = index;
        }
    }
    
    public class OnResetHitItem : CustomEvent { }

    public class OnCatchItem : CustomEvent
    {
        public Bindable Bindable;
        public Vector3 HitLocalPoint;
        public int HitItemPosIndex;

        public OnCatchItem(Bindable item, RaycastHit hit, int hitPosIndex)
        {
            Bindable = item;
            HitLocalPoint = item.transform.InverseTransformPoint(hit.point);
            HitItemPosIndex = hitPosIndex;
        }
    }

    public class OnDropItem : CustomEvent
    {
        public Bindable Bindable;

        public OnDropItem(Bindable item)
        {
            Bindable = item;
        }
    }

    public class OnDetectOtherBind : CustomEvent
    {
        public Bindable Self;
        public Bindable Other;
        public Vector3 SelfPoint;
        public Vector3 OtherPoint;

        public OnDetectOtherBind(Bindable self, Bindable other, Vector3 selfPoint, Vector3 otherPoint)
        {
            Self = self;
            Other = other;
            SelfPoint = selfPoint;
            OtherPoint = otherPoint;
        }
    }
    
    public class OnResetDetectOtherBind : CustomEvent { }
    
    public class OnBindItem : CustomEvent
    {
        public Bindable Self;
        public Bindable Other;

        public OnBindItem(Bindable self, Bindable other)
        {
            Self = self;
            Other = other;
        }
    }

    public class OnUnBindFromRoot : CustomEvent
    {
        public Bindable Self;

        public OnUnBindFromRoot(Bindable self)
        {
            Self = self;
        }
    }
}