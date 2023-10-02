using MyEvent;

namespace Player
{
    public class InactiveState : IUltraHandState
    {
        private PlayerUltraHand playerUltraHand;
        private IInput playerInput;

        public InactiveState(PlayerUltraHand ultraHand, IInput input)
        {
            playerUltraHand = ultraHand;
            playerInput = input;
        }
        
        public void Enter()
        {
            EventManager.RaiseEvent<OnUltraHandDisable>(null);
        }

        public void Stay()
        {
            if (playerInput.UltraHand)
            {
                playerUltraHand.ChangeState(UltraHandStateEnum.Detect);
                return;
            }
        }

        public void Exit()
        {
            
        }
    }
}