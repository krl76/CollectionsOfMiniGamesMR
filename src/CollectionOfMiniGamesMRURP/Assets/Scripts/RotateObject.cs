using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public void RotateOneWay()
    {
        try
        {
            if (FindObjectOfType<ActivateAxis>()._isActivated)
            {
                FindObjectOfType<MainObject>().transform.eulerAngles += new Vector3(0, 10f, 0);
            }
        }
        catch{}
    }
    
    public void RotateSecondWay()
    {
        try
        {
            if (FindObjectOfType<ActivateAxis>()._isActivated)
            {
                FindObjectOfType<MainObject>().transform.eulerAngles -= new Vector3(0, 10f, 0);
            }
        }
        catch{}
    }
}
