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
        
        _inputController = new InputController();

        _inputController.Interaction.ReloadSpace.started += ctx =>
        {
            Destroy(_sceneMesh);
            Invoke(nameof(SpawnSceneMesh), 10f);
            _ = OVRScene.RequestSpaceSetup();
        };
    }

    public void RequestSpaceMesh()
    {
        Destroy(_sceneMesh);
        Invoke(nameof(SpawnSceneMesh), 10f);
        _ = OVRScene.RequestSpaceSetup();
    }

    private void SpawnSceneMesh()
    {
        _sceneMesh = Instantiate(_sceneMeshBlock);
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
