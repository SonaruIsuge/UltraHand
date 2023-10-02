using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    [System.Serializable]
    public class UltraHandAttr
    {
        [Header("Object")] 
        public Transform HandTrans;
        
        [Header("Detect")]
        public float DetectRange;
        public LayerMask DetectLayer;

        [Header("Select")] 
        public float PlayerCloseRange;
        public float PlayerFarRange;
        public float ItemMoveSpeed;
        
        [Header("Bind")]
        // Maximum distance to detect other bindable item
        public float MaxBindableDistance;
        // Maximum detect other bindable item number
        public int MaxBindableDetectCount;
        // Distance between to bindable items when they bind together
        public float BindRange;
        
    }
}