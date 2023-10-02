using UnityEngine;

namespace Player
{
    class NormalMoveStrategy : IMoveStrategy
    {
        private Camera playerCamera;
        private CharacterController playerCc;
        
        private bool isJumpUp;
        private float currentYVelocity;
        
        
        public NormalMoveStrategy(PlayerManager player, MovementAttr attr) : base(player, attr)
        {
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
            var viewDir = player.transform.position - playerCamera.transform.position;
            viewDir.y = 0;
            viewDir.Normalize();
            var viewRightDir = Quaternion.AngleAxis(90, player.transform.up) * viewDir;
            var inputDir = viewDir *  input.Movement.y + viewRightDir * input.Movement.x;

            if (inputDir == Vector3.zero) return;
            
            player.transform.forward = Vector3.Slerp(player.transform.forward, inputDir.normalized,
                attr.RotateAngle * Time.deltaTime);
            var moveSpeed = input.Run ? attr.RunSpeed : attr.MoveSpeed;
            playerCc.Move(inputDir * (moveSpeed * Time.deltaTime));
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
            
            playerCc.Move(player.transform.up * (currentYVelocity * Time.deltaTime));
        }
    }
}