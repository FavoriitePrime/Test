using UnityEngine;

public interface IRaycaster
{
    public bool ThrowRaycast(Vector3 position, out RaycastHit hit, float distance, LayerMask layer);
}