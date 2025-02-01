using System;
using UnityEngine.InputSystem;

public class UIInputController : IDisposable
{
    private Input _input;
    private PlayerInput _playerInput;
    public delegate void onControlsChanged();
    public event onControlsChanged controlsChangedAction;

    public UIInputController(Input input, PlayerInput playerInput) 
    {
        _input = input;
        _playerInput = playerInput;
        _playerInput.onControlsChanged += ControlsChanged;
    }

    public void Dispose()
    {
        _playerInput.onControlsChanged -= ControlsChanged;
    }

    private void ControlsChanged(PlayerInput input)
    {
        controlsChangedAction.Invoke();
    }

    public string GetCurrentControlScheme()
    {
        return _playerInput.currentControlScheme;
    }
}