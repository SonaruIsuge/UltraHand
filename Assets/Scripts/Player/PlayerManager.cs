using System;
using System.Collections;
using System.Collections.Generic;
using MyEvent;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {

        [Header("Component")] 
        [SerializeField] private Camera playerCam;
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private Transform groundCheck;
        
        [Header("Property")] 
        [SerializeField] private MovementAttr movementAttr;
        [SerializeField] private UltraHandAttr ultraHandAttr;

        // Player Components
        private List<PlayerComponent> components = new List<PlayerComponent>();

        public Camera PlayerCam => playerCam;
        public bool IsGround => Physics.Raycast(groundCheck.position, Vector3.down, .01f, movementAttr.GroundLayer);
        public IInput PlayerInput { get; private set; }
        //public MovementAttr MovementAttr => movementAttr;

        private bool enableUltraHand;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
            PlayerInput = new PlayerInput();
            
            components.Add(new PlayerMove(this, movementAttr));
            components.Add(new PlayerUltraHand(this, ultraHandAttr));
        }

        private void Start()
        {
            PlayerInput.Enable(true);
            //playerUltraHand.Init(PlayerInput);
            
            foreach(var component in components) component.Init();
        }

        private void OnEnable()
        {
            PlayerInput.RegisterInput();
            
            foreach(var component in components) component.Enable();
        }

        private void OnDisable()
        {
            PlayerInput.UnregisterInput();
            
            foreach(var component in components) component.Disable();
        }

        private void Update()
        {
            foreach(var component in components) component.Update();
            
            //playerMove.UpdateMove();
            
            SetAnimation();
        }

        private void LateUpdate()
        {
            //playerUltraHand.UpdateUltraHand();
        }


        private void SetAnimation()
        {
            playerAnimator.SetBool("Move", PlayerInput.Movement != Vector2.zero);
            playerAnimator.SetBool("Run", PlayerInput.Run);
        }
    }
}
