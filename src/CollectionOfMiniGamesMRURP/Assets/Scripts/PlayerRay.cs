using System;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{

    [SerializeField] private GameObject _pointer;

    public Ray ray;

    private bool _off;

    private void LateUpdate()
    {
        if (FindObjectOfType<SpawnObjects>()._isSpawn)
        {
            _off = true;
        }
        else
        {
            ray = new Ray(transform.position, transform.forward);
            Debug.DrawRay(transform.position, transform.forward, Color.red);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Floor") && !_off)
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
}
