
using System;
using UnityEngine;

public interface IRayDetector <T>
{
    RaycastHit HitInfo { get; }
    T DetectItem { get; }
    
    bool TryDetectItem(Ray ray, float range, LayerMask mask);
}
