namespace Player
{
    public class PlayerComponent
    {
        public PlayerManager Player { get; private set; }
        public IInput PlayerInput { get; private set; }


        public PlayerComponent(PlayerManager player)
        {
            Player = player;
            PlayerInput = player.PlayerInput;
        }


        public virtual void Init(){}
        public virtual void Update(){}
        public virtual void Enable(){}
        public virtual void Disable(){}
    }
}