using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnArrow : MonoBehaviour
{
    [SerializeField] private GameObject _drotik;

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
            }
            catch{}
        
            _spawned = Instantiate(_drotik, FindObjectOfType<PlayerRay>().transform.position, quaternion.identity);
        }
    }
    
}
