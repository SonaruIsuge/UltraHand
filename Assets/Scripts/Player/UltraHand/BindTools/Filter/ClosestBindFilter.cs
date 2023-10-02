
using Bind;
using MyEvent;
using Player;
using UnityEngine;

public class ClosestBindFilter
{
    private readonly UltraHandAttr ultraHandAttr;
    
    private Vector3 selfPoint;
    private Vector3 otherPoint;

    public Vector3 SelfPoint => selfPoint;
    public Vector3 OtherPoint => otherPoint;
    public float Distance => Vector3.Distance(SelfPoint, otherPoint);


    public ClosestBindFilter(UltraHandAttr attr)
    {
        ultraHandAttr = attr;
        ClearData();
        
        EventManager.Register<OnCatchItem>(CatchItemCallback);
        EventManager.Register<OnDropItem>(DropItemCallback);
    }


    ~ClosestBindFilter()
    {
        EventManager.Unregister<OnCatchItem>(CatchItemCallback);
        EventManager.Unregister<OnDropItem>(DropItemCallback);
    }


    public bool TryGetClosestBindable(Bindable centerBindable, out Bindable closestItem)
    {
        closestItem = null;
        var minDist = Mathf.Infinity;
        var itemClosePoint = Vector3.zero;
        var selfClosePoint = Vector3.zero;
        
        if (!centerBindable) return false;
        
        var colliders = GetNearbyBindable(centerBindable);
        
        foreach (var other in colliders)
        {
            if(!other) continue;
            if(other.transform == centerBindable.transform) continue;
            if(!other.TryGetComponent<Bindable>(out var item)) continue;
            if(centerBindable.IsBindTogether(item)) continue;

            itemClosePoint = other.ClosestPoint(centerBindable.transform.position);
            selfClosePoint = centerBindable.Col.ClosestPoint(itemClosePoint);
            var distance = Vector3.Distance(itemClosePoint, selfClosePoint);

            if(distance >= minDist) continue;

            minDist = distance;
            closestItem = item;
            selfPoint = selfClosePoint;
            otherPoint = itemClosePoint;
        }
        return closestItem;
    }


    public void ClearData()
    {
        selfPoint = Vector3.zero;
        otherPoint = Vector3.zero;
    }


    private Collider[] GetNearbyBindable(Bindable centerItem)
    {
        var results = new Collider[ultraHandAttr.MaxBindableDetectCount];
        Physics.OverlapSphereNonAlloc(centerItem.transform.position,
            centerItem.DetectOtherRange / 2 + ultraHandAttr.MaxBindableDistance, results,
            ultraHandAttr.DetectLayer);
        return results;
    }


    private void CatchItemCallback(OnCatchItem e)
    {
        e.Bindable.DrawGizmosEvent += () => DebugDrawDetectRange(e.Bindable);
    }


    private void DropItemCallback(OnDropItem e)
    {
        e.Bindable.DrawGizmosEvent = null;
    }


    private void DebugDrawDetectRange(Bindable item)
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(item.transform.position, item.DetectOtherRange / 2 + ultraHandAttr.MaxBindableDistance);
    }
}
