using UnityEngine;

public class DartsRay : MonoBehaviour
{
    [SerializeField] private SphereCollider _sphereColliderArrow;
    
    private Ray ray;

    private bool _isPing;

    private void FixedUpdate()
    {
        if (!_isPing)
        {
            //transform.eulerAngles += new Vector3(0, 0, 4f);
        }
    }

    private void LateUpdate()
    {
        ray = new Ray(transform.position, transform.up);
        Debug.DrawRay(transform.position, transform.up * 5, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Arrow"))
            {
                _isPing = true;
            }
        }
    }
}
