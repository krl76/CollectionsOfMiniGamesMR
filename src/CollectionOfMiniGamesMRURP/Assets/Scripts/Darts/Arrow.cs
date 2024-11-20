using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void OffGravity()
    {
        _rb.useGravity = false;
    }
}