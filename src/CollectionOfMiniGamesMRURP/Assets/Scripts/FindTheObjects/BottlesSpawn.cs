using UnityEngine;

public class BottlesSpawn : MonoBehaviour
{
    
    [Header("Spawns")] 
    [SerializeField] private FindSpawnPositions _bottle1;
    [SerializeField] private FindSpawnPositions _bottle2;
    [SerializeField] private FindSpawnPositions _bottle3;
    [SerializeField] private FindSpawnPositions _bottle4;

    private int _amount;
    private int _temp_amount;
    
    public int ActivateSpawn()
    {
        _temp_amount = Random.Range(1, 5);
        _amount += _temp_amount;
        _bottle1.SpawnAmount = _temp_amount;
        
        _temp_amount = Random.Range(1, 5);
        _amount += _temp_amount;
        _bottle2.SpawnAmount = _temp_amount;
        
        _temp_amount = Random.Range(1, 3);
        _amount += _temp_amount;
        _bottle3.SpawnAmount = _temp_amount;
        
        _temp_amount = Random.Range(1, 5);
        _amount += _temp_amount;
        _bottle4.SpawnAmount = _temp_amount;

        _bottle1.enabled = true;
        _bottle2.enabled = true;
        _bottle3.enabled = true;
        _bottle4.enabled = true;
        
        return _amount;
    }
}
