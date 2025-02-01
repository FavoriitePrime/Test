using UnityEngine;

public class RotationHandler
{
    private GamePlayInputHandler _input;
    private Vector2 rotation;

    public RotationHandler(GamePlayInputHandler inputHandler)
    {
        _input = inputHandler;
    }

    public void Rotate(Transform camera, Transform body, float sensivity, Vector2 clampX)
    {
        rotation += sensivity * Time.deltaTime * _input.GetDeltaInput();
        rotation.x = Mathf.Clamp(rotation.x, clampX.x, clampX.y);
        camera.rotation = Quaternion.Euler(rotation.x, rotation.y ,0);
        body.rotation = Quaternion.Euler(0, rotation.y, 0);
    }
}