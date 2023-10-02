using UnityEngine;

namespace Player
{
    class CameraFacingMoveStrategy : IMoveStrategy
    {
        private Transform playerTransform;
        private Camera playerCamera;
        private CharacterController playerCc;

        private float currentYVelocity;
        private bool isJumpUp;
        
        
        public CameraFacingMoveStrategy(PlayerManager player, MovementAttr attr) : base(player, attr)
        {
            playerTransform = player.transform;
            playerCamera = player.PlayerCam;
            playerCc = player.GetComponent<CharacterController>();
        }
        

        public override void Init()
        {
            isJumpUp = false;
            currentYVelocity = 0;
        }

        
        public override void Move()
        {
            var viewDir = playerTransform.position - playerCamera.transform.position;
            viewDir.y = 0;
            viewDir.Normalize();

            playerTransform.forward = 
                Vector3.Slerp(playerTransform.forward, viewDir, attr.RotateAngle * Time.deltaTime);

            var moveDir = playerTransform.forward * input.Movement.y + playerTransform.right * input.Movement.x;
            if (moveDir == Vector3.zero) return;
            
            var moveSpeed = input.Run ? attr.RunSpeed : attr.MoveSpeed;
            playerCc.Move(moveDir * (moveSpeed * Time.deltaTime));
        }
        

        public override void Jump()
        {
            if(!input.Jump) return;
            if(isJumpUp) return;
            
            currentYVelocity = Mathf.Sqrt(attr.JumpForce * -2f * attr.Gravity);
            isJumpUp = true;
        }
        

        public override void HandleGravity()
        {
            if(player.IsGround && currentYVelocity < 0)
            {
                currentYVelocity = -2f;
                isJumpUp = false;
            }
            else currentYVelocity += attr.Gravity * Time.deltaTime;
            
            playerCc.Move(playerTransform.transform.up * (currentYVelocity * Time.deltaTime));
        }
    }
}