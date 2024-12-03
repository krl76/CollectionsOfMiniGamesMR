using System;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Transform _centerOfMass;
    [SerializeField] private float _throwForce;
    [SerializeField] private Transform _direction;
    
    private Rigidbody _rb;
    private HandGrabInteractable grabInteractable;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        //_rb.centerOfMass = _centerOfMass.position;
        
        grabInteractable = GetComponent<HandGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.WhenStateChanged += OnStateChanged;
        }
    }

    private void OnStateChanged(InteractableStateChangeArgs args)
    {
        Debug.LogError(args.PreviousState);
        Debug.LogError((int)args.PreviousState);
        
        if ((int)args.PreviousState == (int)InteractorState.Select)
        {
            _rb.AddForce(_direction.forward * _throwForce, ForceMode.Impulse);
            Debug.LogError($"Object released at time: {Time.time}");
        }
    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.WhenStateChanged -= OnStateChanged;
        }
    }

    public void OffGravity()
    {
        _rb.isKinematic = true;
    }
}