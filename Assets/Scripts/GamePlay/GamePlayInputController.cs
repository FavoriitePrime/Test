using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class GamePlayInputHandler : IDisposable
{
    private Input _input;
    private PlayerInput _playerInput;
    private InputAction _movementInput;
    private InputAction _lookInput;
    private InputAction _pointerPositionInput;
    private InputAction _tapInput;
    public delegate void Tap();
    public event Tap TapAction;

    public GamePlayInputHandler(Input input, PlayerInput playerInput)
    {
        _input = input;
        _input.Enable();
        _playerInput = playerInput;
        _movementInput = _input.GamePlayInput.MovementInput;
        _lookInput = _input.GamePlayInput.LookInput;
        _tapInput = _input.GamePlayInput.Tap;
        _tapInput.performed += OnTap;
        _pointerPositionInput = _input.GamePlayInput.PointerPosition;
    }

    public void Dispose()
    {
        _tapInput.performed -= OnTap;
        _input.Disable();
    }

    private string GetCurrentControlScheme()
    {
        return _playerInput.currentControlScheme;
    }

    private void OnTap(InputAction.CallbackContext context)
    {
        TapAction?.Invoke();
    }

    public Vector2 GetPointerPosition()
    {
        return _pointerPositionInput.ReadValue<Vector2>();  
    }

   public Vector3 GetMovementInput()
   {
        return new Vector3(_movementInput.ReadValue<Vector2>().x, 0 , _movementInput.ReadValue<Vector2>().y);
   }

   public Vector2 GetDeltaInput()
   {
        return new Vector2(_lookInput.ReadValue<Vector2>().y, _lookInput.ReadValue<Vector2>().x);
   }
}