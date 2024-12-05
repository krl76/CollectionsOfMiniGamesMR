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
    
    private List<DartsRay> _dartsRays;

    private GameObject _spawned;

    private SpawnObjects _spawnObjects;
    
    private void Start()
    {
        _spawnObjects = GetComponent<SpawnObjects>();
    }

    public void SpawnDrotik()
    {
        if (_spawnObjects._isSpawn)
        {
            try
            {
                Destroy(_spawned);
                _dartsRays = FindObjectOfType<DartsManager>()._dartsRays;
            }
            catch{}

            foreach (var rays in _dartsRays)
            {
                rays.enabled = true;
            }
            _spawned = Instantiate(_drotik, FindObjectOfType<PlayerRay>().transform.position, quaternion.identity);
        }
    }
    
}
