using ModestTree;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class GamePlayHUDController : MonoBehaviour
{
    public HUDControl[] hudControls;
    public HUDControl defualtHud;
    private UIInputController _input;

    private void Start()
    {
        CheckControlScheme();  
    }

    [Inject]
    private void Init(Input input, PlayerInput playerInput)
    {
        _input = new UIInputController(input, playerInput);
    }

    private void OnEnable()
    {
        _input.controlsChangedAction += onControlsChanged;
    }
    private void OnDisable()
    {
        _input.controlsChangedAction -= onControlsChanged;
    }

    private void onControlsChanged()
    {
        CheckControlScheme();
    }

    private void CheckControlScheme()
    {
        if (hudControls.IsEmpty()) return;
        foreach (var hudControl in hudControls)
        {
            if (_input.GetCurrentControlScheme() == hudControl.Name)
            {
                defualtHud.Disable();
                hudControl.Enable();
                return;
            }
            else
            {
                hudControl.Disable();
            }
        }
        defualtHud.Enable();
    }
}