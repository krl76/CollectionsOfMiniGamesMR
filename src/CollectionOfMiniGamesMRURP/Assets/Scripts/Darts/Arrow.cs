using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Transform _centerOfMass;
    
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        //_rb.centerOfMass = _centerOfMass.position;
    }

    private void Update()
    { }

    public void OffGravity()
    {
        _rb.useGravity = false;
    }
}