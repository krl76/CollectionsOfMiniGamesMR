using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRay : MonoBehaviour
{

    [SerializeField] private GameObject _pointer;

    public Ray ray;
    
    private void LateUpdate()
    {
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Floor") || SceneManager.GetActiveScene().name == "Darts")
            {
                _pointer.SetActive(true);
                _pointer.transform.position = hit.point;
            }
            else
            {
                _pointer.SetActive(false);
            }
        }
    }
}
