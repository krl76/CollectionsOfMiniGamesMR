using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private void Awake()
    {
        transform.position = new Vector3(0, 0.01f,0 );
    }
}
