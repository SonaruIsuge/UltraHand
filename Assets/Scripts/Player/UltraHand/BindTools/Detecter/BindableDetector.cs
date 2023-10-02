
using System;
using Bind;
using UnityEngine;

public class BindableDetector : IRayDetector<Bindable>
{
    public RaycastHit HitInfo { get; private set; }
    public Bindable DetectItem { get; private set; }
    
    
    public bool TryDetectItem(Ray ray, float range, LayerMask mask)
    {
        if (!Physics.Raycast(ray, out var hitInfo, range, mask))
        {
            ResetData();
            return false;
        }
        
        if (!hitInfo.collider.TryGetComponent(out Bindable selectItem))
        {
            ResetData();
            return false;
        }

        HitInfo = hitInfo;
        DetectItem = selectItem;
        return true;
    }


    private void ResetData()
    {
        HitInfo = default;
        DetectItem = null;
    }
}
