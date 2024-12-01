using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnArrow : MonoBehaviour
{
    [SerializeField] private GameObject _drotik;

    private GameObject _spawned;
    
    public void SpawnDrotik()
    {
        try
        {
            Destroy(_spawned);
        }
        catch{}
        
        _spawned = Instantiate(_drotik, FindObjectOfType<PlayerRay>().transform.position, quaternion.identity);
    }
    
}
