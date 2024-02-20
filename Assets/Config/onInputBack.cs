//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Config/onInputBack.inputactions
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

public partial class @OnInputBack: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @OnInputBack()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""onInputBack"",
    ""maps"": [
        {
            ""name"": ""InputBack"",
            ""id"": ""1ffdff64-7f94-460b-b538-19805dc01f77"",
            ""actions"": [
                {
                    ""name"": ""onInputBack"",
                    ""type"": ""Button"",
                    ""id"": ""149fef2c-ccd8-4b61-89a5-00a822bcdacc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ad721b27-07ce-4e0a-9bb3-b89072ac2ebc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""onInputBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // InputBack
        m_InputBack = asset.FindActionMap("InputBack", throwIfNotFound: true);
        m_InputBack_onInputBack = m_InputBack.FindAction("onInputBack", throwIfNotFound: true);
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

    // InputBack
    private readonly InputActionMap m_InputBack;
    private List<IInputBackActions> m_InputBackActionsCallbackInterfaces = new List<IInputBackActions>();
    private readonly InputAction m_InputBack_onInputBack;
    public struct InputBackActions
    {
        private @OnInputBack m_Wrapper;
        public InputBackActions(@OnInputBack wrapper) { m_Wrapper = wrapper; }
        public InputAction @onInputBack => m_Wrapper.m_InputBack_onInputBack;
        public InputActionMap Get() { return m_Wrapper.m_InputBack; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputBackActions set) { return set.Get(); }
        public void AddCallbacks(IInputBackActions instance)
        {
            if (instance == null || m_Wrapper.m_InputBackActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InputBackActionsCallbackInterfaces.Add(instance);
            @onInputBack.started += instance.OnOnInputBack;
            @onInputBack.performed += instance.OnOnInputBack;
            @onInputBack.canceled += instance.OnOnInputBack;
        }

        private void UnregisterCallbacks(IInputBackActions instance)
        {
            @onInputBack.started -= instance.OnOnInputBack;
            @onInputBack.performed -= instance.OnOnInputBack;
            @onInputBack.canceled -= instance.OnOnInputBack;
        }

        public void RemoveCallbacks(IInputBackActions instance)
        {
            if (m_Wrapper.m_InputBackActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInputBackActions instance)
        {
            foreach (var item in m_Wrapper.m_InputBackActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InputBackActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InputBackActions @InputBack => new InputBackActions(this);
    public interface IInputBackActions
    {
        void OnOnInputBack(InputAction.CallbackContext context);
    }
}
