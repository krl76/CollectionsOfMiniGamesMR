using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnArrow : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private GameObject _leftHand;
    [SerializeField] private Vector3 _spawn;
    
    [Header("Other")]
    [SerializeField] private GameObject _drotik;
    [SerializeField] private int _dartsRaysCount;
    [SerializeField] private AudioClip _spawnAudioClip;
    
    private List<DartsRay> _dartsRays;

    private GameObject _spawned;

    private SpawnObjects _spawnObjects;

    private AudioSource _audioSource;
    
    private void Start()
    {
        _spawnObjects = GetComponent<SpawnObjects>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void SpawnDrotik()
    {
        if (_spawnObjects._isSpawn)
        {
            try
            {
                Destroy(_spawned);
                _dartsRays = FindObjectOfType<DartsManager>()._dartsRays;

                foreach (var rays in _dartsRays)
                {
                    rays.enabled = true;
                }
            }
            catch{}

            _audioSource.PlayOneShot(_spawnAudioClip);
            _spawned = Instantiate(_drotik, FindObjectOfType<PlayerRay>().transform.position, quaternion.identity);
        }
    }
    
}
