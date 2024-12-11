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
        if (other.gameObject.CompareTag("BowBall") || other.gameObject.CompareTag("BowPing"))
        {
            _bowlingManager.score += 1;
            
            Invoke(nameof(DisablePin), 3f);
        }
    }

    private void DisablePin()
    {
        gameObject.SetActive(false);
    }
}
