using MyEvent;

namespace Player
{
    public class PlayerMove : PlayerComponent
    {
        private MovementAttr movementAttr;
        private IMoveStrategy strategy;

        private NormalMoveStrategy normalMoveStrategy;
        private CameraFacingMoveStrategy cameraFacingMoveStrategy;
        
        public PlayerMove(PlayerManager player, MovementAttr attr) : base(player)
        {
            movementAttr = attr;

            normalMoveStrategy = new NormalMoveStrategy(player, attr);
            cameraFacingMoveStrategy = new CameraFacingMoveStrategy(player, attr);
            
            strategy = normalMoveStrategy;
        }


        public override void Init()
        {
            base.Init();
        }
        
        
        public override void Enable()
        {
            EventManager.Register<OnUltraHandEnable>(OnEnableUltraHand);
            EventManager.Register<OnUltraHandDisable>(OnDisableUltraHand);
        }


        public override void Disable()
        {
            EventManager.Unregister<OnUltraHandEnable>(OnEnableUltraHand);
            EventManager.Unregister<OnUltraHandDisable>(OnDisableUltraHand);
        }


        public override void Update()
        {
            base.Update();
            
            strategy.HandleGravity();
            strategy.Move();
            strategy.Jump();
        }


        private void OnEnableUltraHand(OnUltraHandEnable e)
        {
            strategy = cameraFacingMoveStrategy;
            strategy.Init();
        }


        private void OnDisableUltraHand(OnUltraHandDisable e)
        {
            strategy = normalMoveStrategy;
            strategy.Init();
        }
    }
}