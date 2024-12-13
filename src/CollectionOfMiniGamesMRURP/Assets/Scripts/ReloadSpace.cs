using System;
using System.Collections;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class ReloadSpace : MonoBehaviour
{
    [SerializeField] private GameObject _sceneMeshBlock;
    [SerializeField] private GameObject _sceneMeshInScene;
    
    private InputController _inputController;
    private GameObject _sceneMesh;

    private void Start()
    {
        _sceneMesh = _sceneMeshInScene;
    }

    public void RequestSpaceMesh()
    {
        Destroy(_sceneMesh);
        var a = OVRScene.RequestSpaceSetup();
        StartCoroutine(StartChecking(a));
    }

    private IEnumerator StartChecking(OVRTask<bool> task)
    {
        while (!task.HasResult) yield return null;
        SpawnSceneMesh();
    }

    private void SpawnSceneMesh()
    {
        _sceneMesh = Instantiate(_sceneMeshBlock, new Vector3(0, 0, 0), quaternion.identity);
    }
}
