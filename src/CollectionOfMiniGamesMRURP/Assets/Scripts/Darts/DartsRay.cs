using System;
using System.Collections.Generic;
using UnityEngine;

public class DartsRay : MonoBehaviour
{
    [SerializeField] private float _speedRay;
    [SerializeField] private List<DartsRay> _anotherRays;
    
    private Ray ray;
    private float _angle;
    private float _speed;

    private void Start()
    {
        _speed = _speedRay;
    }

    private void FixedUpdate()
    {
        transform.eulerAngles += new Vector3(0, 0, _speed);
    }

    private void LateUpdate()
    {
        ray = new Ray(transform.position, transform.up);
        Debug.DrawRay(transform.position, transform.up, Color.red);
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Arrow") && FindObjectOfType<DartsManager>()._isPing)
            {
                _speed = 0f;
                _angle = transform.localEulerAngles.z;
                
                foreach (var rays in _anotherRays)
                {
                    rays.enabled = false;
                }
                
                FindObjectOfType<DartsManager>().Score(_angle);
                
                enabled = false;
            }
        }
    }
}
