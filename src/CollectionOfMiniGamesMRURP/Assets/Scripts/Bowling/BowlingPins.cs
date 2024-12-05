using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPins : MonoBehaviour
{

    private BowlingManager _bowlingManager;
    
    private void Start()
    {
        _bowlingManager = FindObjectOfType<BowlingManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("BowBall"))
        {
            _bowlingManager.score += 1;
            
            Invoke(nameof(DisablePin), 5f);
        }
    }

    private void DisablePin()
    {
        gameObject.SetActive(false);
    }
}
