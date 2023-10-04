using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInput : IInput
    {
        public Vector2 Movement { get; private set; }
        public Vector2 MousePosition { get; private set; }
        public Vector2 MouseMove { get; private set; }
        public bool Run { get; private set; }
        public bool Jump => input.GamePlay.Jump.WasPerformedThisFrame();
        public bool UltraHand => input.GamePlay.Ultrahand.WasPressedThisFrame();
        public bool ChooseItem => input.GamePlay.ChooseItem.WasPressedThisFrame();
        public bool CancelChoose => input.GamePlay.CancelChoose.WasPressedThisFrame();
        public bool Unbind => input.GamePlay.Unbind.WasPressedThisFrame();
        public float AdjustDistance { get; private set; }
        public Vector2 AdjustRotation => input.GamePlay.AdjustRotation.WasPerformedThisFrame() ? rotateDir : Vector2.zero;
        
        
        private Input input;

        private Vector2 rotateDir;


        public PlayerInput()
        {
            input = new Input();
        }
        
        public void Enable(bool enable)
        {
            if(enable) input.Enable();
            else input.Disable();
        }
        
        public void RegisterInput()
        {
            input.GamePlay.Movement.performed += OnMovePerformed;
            input.GamePlay.Movement.canceled += OnMoveCanceled;
            input.GamePlay.MousePosition.performed += OnMousePositionPerformed;
            input.GamePlay.MousePosition.canceled += OnMousePositionCanceled;
            input.GamePlay.MouseMove.performed += OnMouseMovePerformed;
            input.GamePlay.MouseMove.canceled += OnMouseMoveCanceled;
            input.GamePlay.Run.performed += OnRunPerformed;
            input.GamePlay.Run.canceled += OnRunCanceled;
            input.GamePlay.AdjustDistance.performed += OnAdjustDistancePerformed;
            input.GamePlay.AdjustDistance.canceled += OnAdjustDistanceCanceled;
            input.GamePlay.AdjustRotation.performed += OnAdjustRotationPerformed;
            input.GamePlay.AdjustRotation.canceled += OnAdjustRotationCanceled;
        }

        public void UnregisterInput()
        {
            input.GamePlay.Movement.performed -= OnMovePerformed;
            input.GamePlay.Movement.canceled -= OnMoveCanceled;
            input.GamePlay.MousePosition.performed -= OnMousePositionPerformed;
            input.GamePlay.MousePosition.canceled -= OnMousePositionCanceled;
            input.GamePlay.MouseMove.performed -= OnMouseMovePerformed;
            input.GamePlay.MouseMove.canceled -= OnMouseMoveCanceled;
            input.GamePlay.Run.performed -= OnRunPerformed;
            input.GamePlay.Run.canceled -= OnRunCanceled;
            input.GamePlay.AdjustDistance.performed -= OnAdjustDistancePerformed;
            input.GamePlay.AdjustDistance.canceled -= OnAdjustDistanceCanceled;
            input.GamePlay.AdjustRotation.performed -= OnAdjustRotationPerformed;
            input.GamePlay.AdjustRotation.canceled -= OnAdjustRotationCanceled;
        }


        private void OnMovePerformed(InputAction.CallbackContext ctx)
        {
            Movement = ctx.ReadValue<Vector2>();
        }

        private void OnMoveCanceled(InputAction.CallbackContext ctx)
        {
            Movement = Vector2.zero;
        }

        private void OnMousePositionPerformed(InputAction.CallbackContext ctx)
        {
            MousePosition = ctx.ReadValue<Vector2>();
        }

        private void OnMousePositionCanceled(InputAction.CallbackContext ctx)
        {
            MousePosition = Vector2.zero;
        }

        private void OnMouseMovePerformed(InputAction.CallbackContext ctx)
        {
            MouseMove = ctx.ReadValue<Vector2>();
        }

        private void OnMouseMoveCanceled(InputAction.CallbackContext ctx)
        {
            MouseMove = Vector2.zero;
        }

        private void OnRunPerformed(InputAction.CallbackContext ctx)
        {
            Run = true;
        }

        private void OnRunCanceled(InputAction.CallbackContext ctx)
        {
            Run = false;
        }

        private void OnAdjustDistancePerformed(InputAction.CallbackContext ctx)
        {
            var value = ctx.ReadValue<float>();
            AdjustDistance = Mathf.Sign(value);
        }

        private void OnAdjustDistanceCanceled(InputAction.CallbackContext ctx)
        {
            AdjustDistance = 0f;
        }

        private void OnAdjustRotationPerformed(InputAction.CallbackContext ctx)
        {
            var value = ctx.ReadValue<Vector2>();
            if (value.x != 0) value.x = Mathf.Sign(value.x);
            if (value.y != 0) value.y = Mathf.Sign(value.y);
            
            rotateDir = value;
        }

        private void OnAdjustRotationCanceled(InputAction.CallbackContext ctx)
        {
            rotateDir = Vector2.zero;
        }
    }
}