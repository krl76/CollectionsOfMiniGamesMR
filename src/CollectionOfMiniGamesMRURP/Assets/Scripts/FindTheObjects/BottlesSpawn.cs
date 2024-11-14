using UnityEngine;

public class BottlesSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _activate;

    public void ActivateSpawn()
    {
        _activate.SetActive(true);
    }
}
