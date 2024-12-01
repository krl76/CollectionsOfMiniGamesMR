using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Oculus.Interaction.Input;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _pointer;
    
    private bool _isSpawn;

    public void SpawnObject()
    {
        if (_pointer.activeSelf && !_isSpawn)
        {
            Instantiate(_prefab, _pointer.transform.position, Quaternion.identity);
            _isSpawn = true;
        }
    }
}
