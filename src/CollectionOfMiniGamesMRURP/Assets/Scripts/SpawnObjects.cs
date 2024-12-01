using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Oculus.Interaction.Input;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _pointer;
    
    public bool _isSpawn;

    public void SpawnObject()
    {
        if (_pointer.activeSelf && !_isSpawn)
        {
            if (SceneManager.GetActiveScene().name == "Darts")
            {
                Instantiate(_prefab, _pointer.transform.position, _prefab.transform.rotation);
            }
            else
            {
                Instantiate(_prefab, _pointer.transform.position, Quaternion.identity);
            }
            
            _isSpawn = true;
        }
    }
}
