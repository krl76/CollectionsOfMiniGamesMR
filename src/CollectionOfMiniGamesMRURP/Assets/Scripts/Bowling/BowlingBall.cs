using System;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    [SerializeField] private Transform _spawnBall;
    [SerializeField] private float _multiplyForce = 10f;

    private BowlingManager _bowlingManager;
    private HandGrabInteractable grabInteractable;
    private Rigidbody _rb;
    
    private Vector3 _target;
    private bool _select;

    private float _force;

    private void Start()
    {
        grabInteractable = GetComponent<HandGrabInteractable>();
        _rb = GetComponent<Rigidbody>();
        _bowlingManager = GetComponentInParent<BowlingManager>();

        if (grabInteractable != null)
        {
            grabInteractable.WhenStateChanged += OnStateChanged;
        }
    }
    
    private void OnStateChanged(InteractableStateChangeArgs args)
    {
        if (args.NewState == InteractableState.Select)
        {
            _select = true;
        }
        else if (args.PreviousState == InteractableState.Select)
        {
            _select = false;
            GoBall();
        }
        else
        {
            _select = false;
        }
        
    }

    private void FixedUpdate()
    {
        if (_select)
        {
            if (Vector3.Distance(_spawnBall.position, transform.position) < 0.4f)
            {
                _force = Vector3.Distance(_spawnBall.position, transform.position) * _multiplyForce;
            }
        }
    }

    private void GoBall()
    {
        _rb.AddForce(transform.right * _force, ForceMode.Impulse);
        
        Invoke(nameof(InvokeRestoreBall), 5f);
    }

    private void InvokeRestoreBall()
    {
        RestoreBall(false);
    }
    
    public void RestoreBall(bool when)
    {
        if (when)
        {
            transform.position = _spawnBall.position;
            transform.rotation = _spawnBall.rotation;
        }
        else
        {
            _bowlingManager.NewAttemp();
            transform.position = _spawnBall.position;
            transform.rotation = _spawnBall.rotation;
        }
    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.WhenStateChanged -= OnStateChanged;
        }
    }
}
