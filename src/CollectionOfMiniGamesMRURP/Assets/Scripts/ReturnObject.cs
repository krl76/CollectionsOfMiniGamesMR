using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnObject : MonoBehaviour
{
    private float _spawnDistanceFromCamera = 0.75f;
    private OVRCameraRig _cameraRig;
    
    private InputController _inputController;
    
    private void Awake()
    {
        _cameraRig = FindObjectOfType<OVRCameraRig>();
        
        _inputController = new InputController();

        _inputController.Interaction.ReturnUI.started += ctx => StartCoroutine(SnapCanvasInFrontOfCamera());
    }
    
    private void OnEnable()
    {
        _inputController.Enable();
    }

    private void OnDisable()
    {
        _inputController.Disable();
    }

    public void CanvasInFrontOfCamera()
    {
        StartCoroutine(SnapCanvasInFrontOfCamera());
    }

    private void Start()
    {
        StartCoroutine(SnapCanvasInFrontOfCamera());
    }

    private IEnumerator SnapCanvasInFrontOfCamera()
    {
        yield return new WaitUntil(
            () => _cameraRig && _cameraRig.centerEyeAnchor.transform.position != Vector3.zero);
        transform.position = _cameraRig.centerEyeAnchor.transform.position +
                             _cameraRig.centerEyeAnchor.transform.forward * _spawnDistanceFromCamera;
    }
}
