using UnityEngine;

public class Axis : MonoBehaviour
{
    [SerializeField] private Transform _mainObject;
    [SerializeField] private float _smoothSpeed;
    [SerializeField] private Transform _offsetObject;

    private float _offsetY;
    private Vector3 _target;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hands") && FindObjectOfType<ActivateAxisMode>()._isRockLeft)
        {
            _offsetY = _offsetObject.position.y - _mainObject.position.y;
            _target = new Vector3(other.transform.position.x, other.transform.position.y - _offsetY,
                other.transform.position.z);
            
            _mainObject.position = Vector3.Lerp(_mainObject.position, _target, _smoothSpeed);
        }
    }
}
