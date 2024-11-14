using UnityEngine;

public class ActivateAxisMode : MonoBehaviour
{
    public bool _isRockLeft;

    public void RockAction(bool select)
    {
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
