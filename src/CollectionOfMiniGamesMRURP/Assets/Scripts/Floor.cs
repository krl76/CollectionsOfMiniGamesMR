using UnityEngine;

public class Floor : MonoBehaviour
{
    private void Awake()
    {
        transform.position = new Vector3(0, 0.05f,0 );
    }
}
