using UnityEngine;

public class PickUpHandler
{
    private GamePlayInputHandler _gamePlayInputHandler;
    private CameraRaycaster _cameraRaycaster;
    private float _maxDistance;
    private LayerMask _pickableMask;
    private Transform _holder;
    private IPickable _pickable;
    private IDropable _dropable;

    private bool isPicked;

    public PickUpHandler(GamePlayInputHandler gamePlayInputHandler, CameraRaycaster raycaster, float maxDistnace, LayerMask pickableMask, Transform holder)
    {
        _gamePlayInputHandler = gamePlayInputHandler;
        _cameraRaycaster = raycaster;
        _maxDistance = maxDistnace;
        _pickableMask = pickableMask;
        _gamePlayInputHandler.TapAction += HandlePickUpInput;
        _holder = holder;
    }


    private void HandlePickUpInput()
    {
        if (isPicked)
        {
            if (_cameraRaycaster.TryGetComponentFromRaycast<IDropable>(_gamePlayInputHandler.GetPointerPosition(), _maxDistance, _pickableMask, out _dropable))
            {
                Drop();
                return;
            }
        }
        if (!isPicked)
        {
            if(_cameraRaycaster.TryGetComponentFromRaycast<IPickable>(_gamePlayInputHandler.GetPointerPosition(), _maxDistance, _pickableMask, out _pickable))
            {
                PickUp();
            }
        } 
    }

    private void Drop()
    {
        _dropable.Drop();
        isPicked = false;
    }

    private void PickUp()
    {
        _pickable.Pick(_holder);
        isPicked = true;
    }
}