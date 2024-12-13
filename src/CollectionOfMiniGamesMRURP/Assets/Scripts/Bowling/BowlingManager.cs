using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BowlingManager : MonoBehaviour
{
    [Header("Scores")]
    [SerializeField] private TextMeshPro _score1;
    [SerializeField] private TextMeshPro _score2;
    [SerializeField] private TextMeshPro _score3;
    
    public int score;

    [Header("Pins")] 
    [SerializeField] private List<GameObject> _objectPins;
    [SerializeField] private Transform[] _baseTransformPins;

    [Header("Audio")] 
    [SerializeField] private AudioClip _strike;
    [SerializeField] private AudioClip _spare;
    [SerializeField] private AudioClip _click;

    private int memoryScore;
    private int attemp;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Game()
    {
        
        if (score == 10)
        {
            _audioSource.PlayOneShot(_strike);
            
            _score1.text = "STRIKE!";
            _score1.gameObject.SetActive(true);
            _score2.text = score.ToString();
            _score2.gameObject.SetActive(true);
            _score3.text = (Int32.Parse(_score3.text) + score).ToString();
            memoryScore = 0;
            score = 0;
            attemp = 0;
            
            Invoke(nameof(RestorePins), 3f);
        }
        else if (memoryScore + score == 10)
        {
            _audioSource.PlayOneShot(_spare);
            
            _score1.text = "SPARE!";
            _score1.gameObject.SetActive(true);
            _score2.text = score.ToString();
            _score2.gameObject.SetActive(true);
            _score3.text = (Int32.Parse(_score3.text) + score).ToString();
            memoryScore = 0;
            score = 0;
            attemp = 0;
            
            Invoke(nameof(RestorePins), 3f);
        }
        else
        {
            _score1.text = "";
            _score2.text = score.ToString();
            _score2.gameObject.SetActive(true);
            _score3.text = (Int32.Parse(_score3.text) + score).ToString();
            memoryScore = score;
            score = 0;
        }
    }

    private void FixedUpdate()
    {
        if (attemp == 3)
        {
            Invoke(nameof(RestorePins), 2f);
        }
    }

    private void RestorePins()
    {
        for (int i = 0; i < _objectPins.Count; i++)
        {
            _objectPins[i].transform.position = _baseTransformPins[i].position;
            _objectPins[i].transform.rotation = _baseTransformPins[i].rotation;
            _objectPins[i].SetActive(true);
        }
    }

    public void RestartGame()
    {
        _audioSource.PlayOneShot(_click);
        
        _score1.text = _score2.text = _score3.text = "0";
        RestorePins();
        FindObjectOfType<BowlingBall>().RestoreBall(true);
    }
    
    public void NewAttemp()
    {
        attemp += 1;
        _score1.gameObject.SetActive(false);
        _score2.gameObject.SetActive(false);
    }
}
