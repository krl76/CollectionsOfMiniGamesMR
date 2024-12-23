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
    [SerializeField] private AudioClip _spawn;
    
    public bool _isSpawn;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SpawnObject()
    {
        if (_pointer.activeSelf && !_isSpawn)
        {
            if (SceneManager.GetActiveScene().name == "Darts")
            {
                Instantiate(_prefab, new Vector3(_pointer.transform.position.x, _pointer.transform.position.y + 1.4f, _pointer.transform.position.z), _prefab.transform.rotation);
            }
            else if (SceneManager.GetActiveScene().name == "Bowling")
            {
                Instantiate(_prefab, new Vector3(_pointer.transform.position.x, _pointer.transform.position.y + 0.75f, _pointer.transform.position.z), Quaternion.identity);
            }
            else
            {
                Instantiate(_prefab, _pointer.transform.position, Quaternion.identity);
            }
            
            _audioSource.PlayOneShot(_spawn);
            _pointer.SetActive(false);
            _isSpawn = true;
        }
    }
}
