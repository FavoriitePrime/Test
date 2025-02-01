using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour, IPickable, IDropable
{
    private Rigidbody _rigidbody;
    private Transform _holderTransform;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Pick(Transform holder)
    {
        _holderTransform = holder;
    }

    public void Drop()
    {
        _holderTransform = null;   
    }

    private void Update()
    {
        if (_holderTransform == null)
        {
            _rigidbody.useGravity = true;
            return;
        }
        _rigidbody.MovePosition(_holderTransform.position);
        _rigidbody.useGravity = false;
    }
}