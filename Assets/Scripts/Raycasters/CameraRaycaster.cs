using UnityEngine;

public class CameraRaycaster : IRaycaster
{
    private Camera _camera;

    public CameraRaycaster(Camera camera)
    {
        _camera = camera;
    }

    public bool ThrowRaycast(Vector3 position, out RaycastHit hit, float distance, LayerMask layer) 
    {
        return Physics.Raycast(_camera.ScreenPointToRay(position), out hit, distance, layer);
    }

    public bool TryGetComponentFromRaycast<T>(Vector3 position, float distance, LayerMask layer, out T component)
    {
        component = default;
        return Physics.Raycast(_camera.ScreenPointToRay(position), out RaycastHit hit, distance, layer) && hit.transform.TryGetComponent<T>(out component);
    }
}