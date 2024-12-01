using System;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    private bool _selected;
    
    public void SelectRotate(bool select)
    {
        try
        {
            if (FindObjectOfType<ActivateAxis>()._isActivated)
            {
                _selected = select;
            }
        }
        catch{}
    }

    private void Update()
    {
        if(_selected) FindObjectOfType<MainObject>().transform.eulerAngles += new Vector3(0, 5f, 0);
    }
}
