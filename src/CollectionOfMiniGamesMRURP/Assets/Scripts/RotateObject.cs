using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(_selected && SceneManager.GetActiveScene().name == "Darts") FindObjectOfType<MainObject>().transform.eulerAngles += new Vector3(0, 5f, 0);
        else if(_selected) FindObjectOfType<MainObject>().transform.eulerAngles += new Vector3(0, 5f, 0);
    }
}
