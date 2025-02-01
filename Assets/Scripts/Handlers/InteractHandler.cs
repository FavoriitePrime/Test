using UnityEngine;

public class InteractHandler
{
    
    private GamePlayInputHandler _gamePlayInputHandler;
    private CameraRaycaster _cameraRaycaster;
    private float _maxDistance;
    private LayerMask _interactableLayerMask;

    public InteractHandler(GamePlayInputHandler gamePlayInputHandler, CameraRaycaster raycaster, float maxDistnace, LayerMask interactableLayerMask)
    {
        _gamePlayInputHandler = gamePlayInputHandler;
        _cameraRaycaster = raycaster;
        _maxDistance = maxDistnace;
        _interactableLayerMask = interactableLayerMask;
        _gamePlayInputHandler.TapAction += HandleInteractInput;
    }

    private void HandleInteractInput()
    {
        if(_cameraRaycaster.TryGetComponentFromRaycast<IInteractable>(_gamePlayInputHandler.GetPointerPosition(), _maxDistance, _interactableLayerMask, out IInteractable interactable))
        {
            interactable.Interact();
        }
    }
}