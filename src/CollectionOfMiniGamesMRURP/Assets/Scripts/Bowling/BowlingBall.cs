using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    [SerializeField] private float _smoothSpeed;
    
    private HandGrabInteractable grabInteractable;
    private Rigidbody _rb;

    private Vector3 _basePosition;
    private Vector3 _target;
    private bool _select;

    private float _force;

    private void Awake()
    {
        _basePosition = transform.position;
    }

    private void Start()
    {
        grabInteractable = GetComponent<HandGrabInteractable>();
        _rb = GetComponent<Rigidbody>();
        
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
        else
        {
            _select = false;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hands") && _select)
        {
            if (Vector3.Distance(_basePosition, transform.position) < 2f)
            {
                _target = new Vector3(other.transform.position.x, other.transform.position.y,
                    other.transform.position.z);

                _force = Vector3.Distance(_basePosition, transform.position);
            
                transform.position = Vector3.Lerp(transform.position, _target, _smoothSpeed);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _rb.AddForce(transform.right * _force, ForceMode.Impulse);
        
        Invoke(nameof(RestoreBall), 5f);
    }

    public void RestoreBall()
    {
        transform.position = _basePosition;
    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.WhenStateChanged -= OnStateChanged;
        }
    }
}
