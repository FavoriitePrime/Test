using UnityEngine;

public class MovementHandler
{
    private GamePlayInputHandler _input;
 
    public MovementHandler(GamePlayInputHandler inputHandler)
    {
        _input = inputHandler;
    }

    public void Move(CharacterController characterController, float speed)
    {
        characterController.Move(characterController.transform.rotation * _input.GetMovementInput() * speed * Time.deltaTime);
    }
}