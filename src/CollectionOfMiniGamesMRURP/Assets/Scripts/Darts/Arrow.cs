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
    
    private Vector3 _prevPos;
    private float _speed;
    public bool _throw;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _prevPos = transform.position;

        //_rb.centerOfMass = _centerOfMass.position;
        
        grabInteractable = GetComponent<HandGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.WhenStateChanged += OnStateChanged;
        }
    }

    private void FixedUpdate()
    {
        Vector3 displacement = transform.position - _prevPos;
        _speed = displacement.magnitude / Time.deltaTime;
        _prevPos = transform.position;
        
        if(_speed > 4) Debug.LogError($"Drotik speed: {_speed}");
    }

    private void OnStateChanged(InteractableStateChangeArgs args)
    {
        Debug.LogError($"{args.NewState}.");

        if (_throw)
        {
            return;
        }
        if (args.NewState != InteractableState.Select && _speed >= 4.3f)
        {
            _throw = true;
            _rb.isKinematic = false;
            _rb.AddForce(_direction.forward * _throwForce, ForceMode.Impulse);
        }
        else if (args.NewState != InteractableState.Select && _speed < 4.3f && !_throw)
        {
            _rb.isKinematic = true;
        }
        
        /*if ((int)args.PreviousState == (int)InteractorState.Select)
        {
            _rb.AddForce(_direction.forward * _throwForce, ForceMode.Impulse);
            Debug.LogError($"Object released at time: {Time.time}");
        }*/
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