//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Input/Input.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Input: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""1d810ce0-fb89-4af8-aa8d-cf9a57f1bd9a"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""37d94447-a73b-4cb7-ab12-3097c9b898ab"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""ec98b112-9221-483a-8bbb-ec0c1aa620a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""830901e4-f5c5-4ae4-b93e-e8c923f94f41"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseMove"",
                    ""type"": ""Value"",
                    ""id"": ""2525b9c8-f28e-4f01-8b8c-c24f2f3e1403"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""46e9a2b3-e84f-4202-a7bc-9892a7d060de"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Ultrahand"",
                    ""type"": ""Button"",
                    ""id"": ""a14f6727-ca20-4fc6-a55b-bef1c4e4f6a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ChooseItem"",
                    ""type"": ""Button"",
                    ""id"": ""34718c4d-cacd-4813-a81b-62d86f187f37"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CancelChoose"",
                    ""type"": ""Button"",
                    ""id"": ""afd36f78-51bb-46e4-8845-92c3dcbb44b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Unbind"",
                    ""type"": ""Button"",
                    ""id"": ""f8842983-cb54-44a6-880e-883b00b7e6de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AdjustDistance"",
                    ""type"": ""Value"",
                    ""id"": ""4c12c67a-baef-422c-a785-a4363f3a4ecd"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""AdjustRotation"",
                    ""type"": ""Value"",
                    ""id"": ""c7c7213b-2ac2-4dd3-a490-41a5c5ab0e10"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""7a774db9-a5ba-400a-86a7-89979149ad1d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d3b9ff77-7e15-45f2-a4a8-d26f3bcddf34"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2f760104-788a-405c-ad0d-d55559b0e131"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""53e98f05-e791-4500-a804-61f7b72d48ae"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4427be3b-81d4-4507-8b3b-d21dbdaea2bb"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""936f10c8-6483-43ba-863f-a0e661888aac"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ultrahand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7860a0fe-3de6-494c-8bf7-efb83a57f087"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChooseItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0b578f0-398f-404c-9263-317a83538562"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79da43a0-0be4-43cb-a34a-1904427e75cb"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e76c35c0-d3b5-4096-9dcf-67f4c53d2b2f"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CancelChoose"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37c8381c-1a6a-416a-90b3-16e8fb6d544f"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Unbind"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12bc7e58-08c5-42ac-8fff-f0cfb50adf95"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7b092f6-b3fc-4355-9142-c186011613d6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""92edd9af-21c5-43f0-be65-e011c07086ff"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdjustDistance"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b0b78e97-2768-462e-b0be-a98e9298fffb"",
                    ""path"": ""<Mouse>/scroll/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdjustDistance"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7eb5c4e6-c350-4879-92ed-a111e8cb1d29"",
                    ""path"": ""<Mouse>/scroll/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdjustDistance"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d18924bd-7d57-4c0a-9d5d-bd6be43571fa"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdjustRotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2c59fc5f-1db2-479c-b0cd-b020971fda27"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdjustRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b782d319-1357-44f5-bd3b-1fe3165998eb"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdjustRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7e33b306-7ea1-4b2d-b319-0135f70b481f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdjustRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5b31bcda-e0ad-4c61-8c56-425542b79c82"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdjustRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_Movement = m_GamePlay.FindAction("Movement", throwIfNotFound: true);
        m_GamePlay_Run = m_GamePlay.FindAction("Run", throwIfNotFound: true);
        m_GamePlay_Jump = m_GamePlay.FindAction("Jump", throwIfNotFound: true);
        m_GamePlay_MouseMove = m_GamePlay.FindAction("MouseMove", throwIfNotFound: true);
        m_GamePlay_MousePosition = m_GamePlay.FindAction("MousePosition", throwIfNotFound: true);
        m_GamePlay_Ultrahand = m_GamePlay.FindAction("Ultrahand", throwIfNotFound: true);
        m_GamePlay_ChooseItem = m_GamePlay.FindAction("ChooseItem", throwIfNotFound: true);
        m_GamePlay_CancelChoose = m_GamePlay.FindAction("CancelChoose", throwIfNotFound: true);
        m_GamePlay_Unbind = m_GamePlay.FindAction("Unbind", throwIfNotFound: true);
        m_GamePlay_AdjustDistance = m_GamePlay.FindAction("AdjustDistance", throwIfNotFound: true);
        m_GamePlay_AdjustRotation = m_GamePlay.FindAction("AdjustRotation", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private List<IGamePlayActions> m_GamePlayActionsCallbackInterfaces = new List<IGamePlayActions>();
    private readonly InputAction m_GamePlay_Movement;
    private readonly InputAction m_GamePlay_Run;
    private readonly InputAction m_GamePlay_Jump;
    private readonly InputAction m_GamePlay_MouseMove;
    private readonly InputAction m_GamePlay_MousePosition;
    private readonly InputAction m_GamePlay_Ultrahand;
    private readonly InputAction m_GamePlay_ChooseItem;
    private readonly InputAction m_GamePlay_CancelChoose;
    private readonly InputAction m_GamePlay_Unbind;
    private readonly InputAction m_GamePlay_AdjustDistance;
    private readonly InputAction m_GamePlay_AdjustRotation;
    public struct GamePlayActions
    {
        private @Input m_Wrapper;
        public GamePlayActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_GamePlay_Movement;
        public InputAction @Run => m_Wrapper.m_GamePlay_Run;
        public InputAction @Jump => m_Wrapper.m_GamePlay_Jump;
        public InputAction @MouseMove => m_Wrapper.m_GamePlay_MouseMove;
        public InputAction @MousePosition => m_Wrapper.m_GamePlay_MousePosition;
        public InputAction @Ultrahand => m_Wrapper.m_GamePlay_Ultrahand;
        public InputAction @ChooseItem => m_Wrapper.m_GamePlay_ChooseItem;
        public InputAction @CancelChoose => m_Wrapper.m_GamePlay_CancelChoose;
        public InputAction @Unbind => m_Wrapper.m_GamePlay_Unbind;
        public InputAction @AdjustDistance => m_Wrapper.m_GamePlay_AdjustDistance;
        public InputAction @AdjustRotation => m_Wrapper.m_GamePlay_AdjustRotation;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void AddCallbacks(IGamePlayActions instance)
        {
            if (instance == null || m_Wrapper.m_GamePlayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GamePlayActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Run.started += instance.OnRun;
            @Run.performed += instance.OnRun;
            @Run.canceled += instance.OnRun;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @MouseMove.started += instance.OnMouseMove;
            @MouseMove.performed += instance.OnMouseMove;
            @MouseMove.canceled += instance.OnMouseMove;
            @MousePosition.started += instance.OnMousePosition;
            @MousePosition.performed += instance.OnMousePosition;
            @MousePosition.canceled += instance.OnMousePosition;
            @Ultrahand.started += instance.OnUltrahand;
            @Ultrahand.performed += instance.OnUltrahand;
            @Ultrahand.canceled += instance.OnUltrahand;
            @ChooseItem.started += instance.OnChooseItem;
            @ChooseItem.performed += instance.OnChooseItem;
            @ChooseItem.canceled += instance.OnChooseItem;
            @CancelChoose.started += instance.OnCancelChoose;
            @CancelChoose.performed += instance.OnCancelChoose;
            @CancelChoose.canceled += instance.OnCancelChoose;
            @Unbind.started += instance.OnUnbind;
            @Unbind.performed += instance.OnUnbind;
            @Unbind.canceled += instance.OnUnbind;
            @AdjustDistance.started += instance.OnAdjustDistance;
            @AdjustDistance.performed += instance.OnAdjustDistance;
            @AdjustDistance.canceled += instance.OnAdjustDistance;
            @AdjustRotation.started += instance.OnAdjustRotation;
            @AdjustRotation.performed += instance.OnAdjustRotation;
            @AdjustRotation.canceled += instance.OnAdjustRotation;
        }

        private void UnregisterCallbacks(IGamePlayActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Run.started -= instance.OnRun;
            @Run.performed -= instance.OnRun;
            @Run.canceled -= instance.OnRun;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @MouseMove.started -= instance.OnMouseMove;
            @MouseMove.performed -= instance.OnMouseMove;
            @MouseMove.canceled -= instance.OnMouseMove;
            @MousePosition.started -= instance.OnMousePosition;
            @MousePosition.performed -= instance.OnMousePosition;
            @MousePosition.canceled -= instance.OnMousePosition;
            @Ultrahand.started -= instance.OnUltrahand;
            @Ultrahand.performed -= instance.OnUltrahand;
            @Ultrahand.canceled -= instance.OnUltrahand;
            @ChooseItem.started -= instance.OnChooseItem;
            @ChooseItem.performed -= instance.OnChooseItem;
            @ChooseItem.canceled -= instance.OnChooseItem;
            @CancelChoose.started -= instance.OnCancelChoose;
            @CancelChoose.performed -= instance.OnCancelChoose;
            @CancelChoose.canceled -= instance.OnCancelChoose;
            @Unbind.started -= instance.OnUnbind;
            @Unbind.performed -= instance.OnUnbind;
            @Unbind.canceled -= instance.OnUnbind;
            @AdjustDistance.started -= instance.OnAdjustDistance;
            @AdjustDistance.performed -= instance.OnAdjustDistance;
            @AdjustDistance.canceled -= instance.OnAdjustDistance;
            @AdjustRotation.started -= instance.OnAdjustRotation;
            @AdjustRotation.performed -= instance.OnAdjustRotation;
            @AdjustRotation.canceled -= instance.OnAdjustRotation;
        }

        public void RemoveCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGamePlayActions instance)
        {
            foreach (var item in m_Wrapper.m_GamePlayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GamePlayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    public interface IGamePlayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMouseMove(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnUltrahand(InputAction.CallbackContext context);
        void OnChooseItem(InputAction.CallbackContext context);
        void OnCancelChoose(InputAction.CallbackContext context);
        void OnUnbind(InputAction.CallbackContext context);
        void OnAdjustDistance(InputAction.CallbackContext context);
        void OnAdjustRotation(InputAction.CallbackContext context);
    }
}
