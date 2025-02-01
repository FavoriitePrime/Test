using UnityEngine;
using UnityEngine.Events;

public class InteractObject: MonoBehaviour, IInteractable
{
    [SerializeField] private Animation[] _animations;
    [SerializeField] private UnityEvent events;

    public void Interact()
    {
        foreach (var animation in _animations)
        {
            animation.Play();
        }
        events.Invoke();
    }
}
