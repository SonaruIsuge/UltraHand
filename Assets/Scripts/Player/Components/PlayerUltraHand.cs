using System;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    [Serializable]
    public class PlayerUltraHand : PlayerComponent
    {
        private UltraHandAttr attr;
        private UltraHandProps props;
        private UltraHandStateEnum currentStateEnum;
        private Dictionary<UltraHandStateEnum, IUltraHandState> stateDictionary;

        public UltraHandAttr Attr => attr;
        public UltraHandProps Props => props;


        public PlayerUltraHand(PlayerManager player, UltraHandAttr attr) : base(player)
        {
            this.attr = attr;
            this.props = new UltraHandProps();
        }
        
        
        public override void Init()
        {
            stateDictionary = new Dictionary<UltraHandStateEnum, IUltraHandState>
            {
                { UltraHandStateEnum.Inactive, new InactiveState(this, PlayerInput) },
                { UltraHandStateEnum.Detect, new DetectState(this, PlayerInput) },
                { UltraHandStateEnum.Select , new SelectState(this, PlayerInput) }
            };

            ChangeState(UltraHandStateEnum.Inactive);
        }


        public override void Enable()
        {
            base.Enable();
        }


        public override void Disable()
        {
            base.Disable();
        }


        public override void Update()
        {
            stateDictionary[currentStateEnum].Stay();
        }


        public void ChangeState(UltraHandStateEnum newStateEnum)
        {
            if(stateDictionary == null) return;
            
            if(stateDictionary.ContainsKey(currentStateEnum)) stateDictionary[currentStateEnum].Exit();
            currentStateEnum = newStateEnum;
            if(stateDictionary.ContainsKey(currentStateEnum)) stateDictionary[currentStateEnum].Enter();
        }
    }
}