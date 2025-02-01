using UnityEngine.InputSystem;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    [Header("Rotation")]
    [SerializeField] private Transform _cameraFollowTarget;
    [SerializeField] private float sensivity;
    [Tooltip("Clamp where X is min and Y is Max")]
    [SerializeField] [InRange(-45f, 45f)] public Vector2 clampXAxis;
    [Header("Interaction Action")]
    [SerializeField] private Camera _raycastCamera;
    [SerializeField] private float _distance;
    [SerializeField] private Transform _holder;
    [SerializeField] private LayerMask _interactableLayerMask;
    [Header("Pick up Action")]
    [SerializeField] private LayerMask _pickableLayerMask;
    private CharacterController _characterController;
    private MovementHandler _movementHandler;
    private RotationHandler _rotationHandler;
    private InteractHandler _interactHandler;
    private PickUpHandler _pickUpHandler;
    private GamePlayInputHandler _gamePlayInputHandler;
    private CameraRaycaster _cameraRaycaster;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _cameraRaycaster = new CameraRaycaster(_raycastCamera);
        _interactHandler = new InteractHandler(_gamePlayInputHandler, _cameraRaycaster, _distance, _interactableLayerMask);
        _pickUpHandler = new PickUpHandler(_gamePlayInputHandler, _cameraRaycaster, _distance, _pickableLayerMask, _holder);
        _movementHandler = new MovementHandler(_gamePlayInputHandler);
        _rotationHandler = new RotationHandler(_gamePlayInputHandler);
    }

    [Inject]
    private void Init(Input input, PlayerInput playerInput)
    {
        _gamePlayInputHandler = new GamePlayInputHandler(input, playerInput);
    }

    private void Update()
    {
        _movementHandler.Move(_characterController, speed);
        _rotationHandler.Rotate(_cameraFollowTarget, transform, sensivity, clampXAxis);
    }
}