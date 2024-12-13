using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPins : MonoBehaviour
{
    [SerializeField] private AudioClip _fall;

    private AudioSource _audioSource;
    private BowlingManager _bowlingManager;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _bowlingManager = FindObjectOfType<BowlingManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("BowPing"))
        {
            if (!other.gameObject.GetComponent<CheckPin>()._check)
            {
                other.gameObject.GetComponent<CheckPin>()._check = true;
                GetComponent<CheckPin>()._check = true;
                _audioSource.PlayOneShot(_fall);
                _bowlingManager.score += 1;
            
                Invoke(nameof(DisablePin), 2f);
            }
        }
        
        if (other.gameObject.CompareTag("BowBall"))
        {
            GetComponent<CheckPin>()._check = true;
            _audioSource.PlayOneShot(_fall);
            _bowlingManager.score += 1;
            
            Invoke(nameof(DisablePin), 2f);
        }
    }

    private void DisablePin()
    {
        gameObject.SetActive(false);
    }
}
