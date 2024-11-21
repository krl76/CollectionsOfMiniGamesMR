using Unity.Mathematics;
using UnityEngine;

public class ReloadSpace : MonoBehaviour
{
    [SerializeField] private GameObject _sceneMeshBlock;
    
    private InputController _inputController;
    private GameObject _sceneMesh;

    private void Awake()
    {
        _sceneMesh = Instantiate(_sceneMeshBlock, new Vector3(0, 0, 0), quaternion.identity);
    }

    public void RequestSpaceMesh()
    {
        Destroy(_sceneMesh);
        _ = OVRScene.RequestSpaceSetup();
        Invoke(nameof(SpawnSceneMesh), 30f);
    }

    private void SpawnSceneMesh()
    {
        _sceneMesh = Instantiate(_sceneMeshBlock, new Vector3(0, 0, 0), quaternion.identity);
    }
    
    private void OnEnable()
    {
        _inputController.Enable();
    }

    private void OnDisable()
    {
        _inputController.Disable();
    }
}
