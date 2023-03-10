//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Resources/Input/Input.inputactions
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

public partial class @Input : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""Building"",
            ""id"": ""27e860ee-70b4-44f6-91e0-663a1f53aa72"",
            ""actions"": [
                {
                    ""name"": ""Follow"",
                    ""type"": ""Value"",
                    ""id"": ""8576f931-7f53-4c76-b44d-a7f83a13be48"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Place"",
                    ""type"": ""Button"",
                    ""id"": ""08dae605-2a2b-4c9a-8954-1ef5e1e9e1e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Detach"",
                    ""type"": ""Button"",
                    ""id"": ""b2dc61e0-1cb8-49fe-8e26-0344a563aa13"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""baa1d4a0-53e3-4a04-a206-bbe205646956"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gameplay"",
                    ""action"": ""Follow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6547d454-6e5b-4251-a8f4-857f1b2b703d"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Detach"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""99589fc8-17c2-4638-b14b-3411db3af9d4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Place"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Command"",
            ""id"": ""7b1c69ec-3c2d-43f3-9a4d-6839a3928b08"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Value"",
                    ""id"": ""fb1a929f-b99d-4e50-9bc9-b0a1442eaa9e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ActionPoint"",
                    ""type"": ""Value"",
                    ""id"": ""ae2f8741-9e6b-4644-8792-b4243cb6abda"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""AdditionalActionPoint"",
                    ""type"": ""Button"",
                    ""id"": ""552c93e9-e5bd-45f6-b8ec-771b9fd6b705"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Modifier"",
                    ""id"": ""30198ee5-6aab-4e9c-b3ac-0086a76d8a1d"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Modifier"",
                    ""id"": ""e7ddc449-36fe-4c44-94c1-683f43a8b004"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Binding"",
                    ""id"": ""bc48ccc6-aa28-479c-acd6-56b727268899"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Modifier"",
                    ""id"": ""93595781-b42b-4e9d-88e9-72696fe0773c"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionPoint"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""c696d733-a575-4fcf-ac41-5444b2f85777"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionPoint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""1a119419-07de-4aef-be20-2394e522f34b"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionPoint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Modifier"",
                    ""id"": ""69ea4793-071b-4953-afd8-6f8211ea1119"",
                    ""path"": ""TwoModifiers"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdditionalActionPoint"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier1"",
                    ""id"": ""bd9bbf35-2d5e-482e-aeca-1875ebda52cb"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdditionalActionPoint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""modifier2"",
                    ""id"": ""bb04593d-9f7d-4ba2-aad5-4f87d6b8b337"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdditionalActionPoint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""bafdb2f0-3d3a-419c-926a-6c14b5afeee4"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdditionalActionPoint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gameplay"",
            ""bindingGroup"": ""Gameplay"",
            ""devices"": []
        }
    ]
}");
        // Building
        m_Building = asset.FindActionMap("Building", throwIfNotFound: true);
        m_Building_Follow = m_Building.FindAction("Follow", throwIfNotFound: true);
        m_Building_Place = m_Building.FindAction("Place", throwIfNotFound: true);
        m_Building_Detach = m_Building.FindAction("Detach", throwIfNotFound: true);
        // Command
        m_Command = asset.FindActionMap("Command", throwIfNotFound: true);
        m_Command_Select = m_Command.FindAction("Select", throwIfNotFound: true);
        m_Command_ActionPoint = m_Command.FindAction("ActionPoint", throwIfNotFound: true);
        m_Command_AdditionalActionPoint = m_Command.FindAction("AdditionalActionPoint", throwIfNotFound: true);
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

    // Building
    private readonly InputActionMap m_Building;
    private IBuildingActions m_BuildingActionsCallbackInterface;
    private readonly InputAction m_Building_Follow;
    private readonly InputAction m_Building_Place;
    private readonly InputAction m_Building_Detach;
    public struct BuildingActions
    {
        private @Input m_Wrapper;
        public BuildingActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Follow => m_Wrapper.m_Building_Follow;
        public InputAction @Place => m_Wrapper.m_Building_Place;
        public InputAction @Detach => m_Wrapper.m_Building_Detach;
        public InputActionMap Get() { return m_Wrapper.m_Building; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BuildingActions set) { return set.Get(); }
        public void SetCallbacks(IBuildingActions instance)
        {
            if (m_Wrapper.m_BuildingActionsCallbackInterface != null)
            {
                @Follow.started -= m_Wrapper.m_BuildingActionsCallbackInterface.OnFollow;
                @Follow.performed -= m_Wrapper.m_BuildingActionsCallbackInterface.OnFollow;
                @Follow.canceled -= m_Wrapper.m_BuildingActionsCallbackInterface.OnFollow;
                @Place.started -= m_Wrapper.m_BuildingActionsCallbackInterface.OnPlace;
                @Place.performed -= m_Wrapper.m_BuildingActionsCallbackInterface.OnPlace;
                @Place.canceled -= m_Wrapper.m_BuildingActionsCallbackInterface.OnPlace;
                @Detach.started -= m_Wrapper.m_BuildingActionsCallbackInterface.OnDetach;
                @Detach.performed -= m_Wrapper.m_BuildingActionsCallbackInterface.OnDetach;
                @Detach.canceled -= m_Wrapper.m_BuildingActionsCallbackInterface.OnDetach;
            }
            m_Wrapper.m_BuildingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Follow.started += instance.OnFollow;
                @Follow.performed += instance.OnFollow;
                @Follow.canceled += instance.OnFollow;
                @Place.started += instance.OnPlace;
                @Place.performed += instance.OnPlace;
                @Place.canceled += instance.OnPlace;
                @Detach.started += instance.OnDetach;
                @Detach.performed += instance.OnDetach;
                @Detach.canceled += instance.OnDetach;
            }
        }
    }
    public BuildingActions @Building => new BuildingActions(this);

    // Command
    private readonly InputActionMap m_Command;
    private ICommandActions m_CommandActionsCallbackInterface;
    private readonly InputAction m_Command_Select;
    private readonly InputAction m_Command_ActionPoint;
    private readonly InputAction m_Command_AdditionalActionPoint;
    public struct CommandActions
    {
        private @Input m_Wrapper;
        public CommandActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_Command_Select;
        public InputAction @ActionPoint => m_Wrapper.m_Command_ActionPoint;
        public InputAction @AdditionalActionPoint => m_Wrapper.m_Command_AdditionalActionPoint;
        public InputActionMap Get() { return m_Wrapper.m_Command; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CommandActions set) { return set.Get(); }
        public void SetCallbacks(ICommandActions instance)
        {
            if (m_Wrapper.m_CommandActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_CommandActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_CommandActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_CommandActionsCallbackInterface.OnSelect;
                @ActionPoint.started -= m_Wrapper.m_CommandActionsCallbackInterface.OnActionPoint;
                @ActionPoint.performed -= m_Wrapper.m_CommandActionsCallbackInterface.OnActionPoint;
                @ActionPoint.canceled -= m_Wrapper.m_CommandActionsCallbackInterface.OnActionPoint;
                @AdditionalActionPoint.started -= m_Wrapper.m_CommandActionsCallbackInterface.OnAdditionalActionPoint;
                @AdditionalActionPoint.performed -= m_Wrapper.m_CommandActionsCallbackInterface.OnAdditionalActionPoint;
                @AdditionalActionPoint.canceled -= m_Wrapper.m_CommandActionsCallbackInterface.OnAdditionalActionPoint;
            }
            m_Wrapper.m_CommandActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @ActionPoint.started += instance.OnActionPoint;
                @ActionPoint.performed += instance.OnActionPoint;
                @ActionPoint.canceled += instance.OnActionPoint;
                @AdditionalActionPoint.started += instance.OnAdditionalActionPoint;
                @AdditionalActionPoint.performed += instance.OnAdditionalActionPoint;
                @AdditionalActionPoint.canceled += instance.OnAdditionalActionPoint;
            }
        }
    }
    public CommandActions @Command => new CommandActions(this);
    private int m_GameplaySchemeIndex = -1;
    public InputControlScheme GameplayScheme
    {
        get
        {
            if (m_GameplaySchemeIndex == -1) m_GameplaySchemeIndex = asset.FindControlSchemeIndex("Gameplay");
            return asset.controlSchemes[m_GameplaySchemeIndex];
        }
    }
    public interface IBuildingActions
    {
        void OnFollow(InputAction.CallbackContext context);
        void OnPlace(InputAction.CallbackContext context);
        void OnDetach(InputAction.CallbackContext context);
    }
    public interface ICommandActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnActionPoint(InputAction.CallbackContext context);
        void OnAdditionalActionPoint(InputAction.CallbackContext context);
    }
}
