using System;
using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{

    [SerializeField] private GameObject _pointer;

    public Ray ray;
    
    private void LateUpdate()
    {
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Floor"))
            {
                _pointer.SetActive(true);
                _pointer.transform.position = hit.point;
            }
            else
            {
                _pointer.SetActive(false);
            }
        }
    }
}
