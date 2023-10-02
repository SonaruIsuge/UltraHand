using UnityEngine;

namespace Player
{
    [System.Serializable]
    public class MovementAttr
    {
        public LayerMask GroundLayer;
        public float Gravity;
        public float MoveSpeed;
        public float RotateAngle;
        public float RunSpeed;
        public float JumpForce;
    }
}