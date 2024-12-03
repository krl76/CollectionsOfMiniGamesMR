using System;
using UnityEngine;

public class ActivateAxisMode : MonoBehaviour
{
    public bool _isRockLeft;

    private SphereCollider _colliderFinger;

    private void Start()
    {
        _colliderFinger = FindObjectOfType<PlayerRay>().GetComponent<SphereCollider>();
    }

    public void RockAction(bool select)
    {
        if (!select) _colliderFinger.isTrigger = true;
        else _colliderFinger.isTrigger = false;
        
        _isRockLeft = select;
    }

    public void StopAction()
    {
        try
        {
            FindObjectOfType<ActivateAxis>().Activate();
        }
        catch { }
    }
}
