using UnityEngine;

public class ActivateAxis : MonoBehaviour
{
    [SerializeField] private GameObject _object;

    public bool _isActivated;

    public void Activate()
    {
        if (!_isActivated)
        {
            _object.SetActive(true);
            _isActivated = true;
        }
        else
        {
            _object.SetActive(false);
            _isActivated = false;
        }
    }
}
