using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _pointer;

    public void SpawnObject()
    {
        if (_pointer.activeSelf)
        {
            Instantiate(_prefab, _pointer.transform.position, Quaternion.identity);
        }
    }
}
