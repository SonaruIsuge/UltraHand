
using Bind;
using UnityEngine;

namespace Player
{
    [System.Serializable]
    public class UltraHandProps
    {
        // Detect props
        public Bindable DetectItem { get; set; }
        public RaycastHit HitInfo { get; set; }
        public int CloseBindPosIndex { get; set; }
        
        // Select props
        public Bindable SelectItem { get; set; }
        public Bindable ClosestItem { get; set; }
        public Vector3 HitPoint { get; set; }
        
        
        // Record the position and rotation related value when selected
        public Vector3 PlayerHitPointVec { get; set; }
        public Vector3 HitPointCenterDrift { get; set; }
        public Vector3 SelectedScreenPos { get; set; }
        public Quaternion OffsetPlayerRotate { get; set; }
        public Quaternion SelectedItemRotate { get; set; }
        public Quaternion PlayerRelateRotation { get; set; }
    }
}