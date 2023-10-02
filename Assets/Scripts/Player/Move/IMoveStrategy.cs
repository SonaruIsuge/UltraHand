namespace Player
{
    abstract class IMoveStrategy
    {
        protected PlayerManager player;
        protected MovementAttr attr;
        protected IInput input;

        public IMoveStrategy(PlayerManager player, MovementAttr attr)
        {
            this.player = player;
            this.attr = attr;
            input = player.PlayerInput;
        }

        public abstract void Init();
        public abstract void Move();
        public abstract void Jump();
        public abstract void HandleGravity();
    }
}