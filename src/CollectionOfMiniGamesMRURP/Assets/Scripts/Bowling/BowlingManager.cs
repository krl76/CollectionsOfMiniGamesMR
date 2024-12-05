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
    [SerializeField] private List<Transform> _transformsPins;

    private List<Transform> _baseTransformsPins;

    private void Awake()
    {
        foreach (var pin in _transformsPins)
        {
            _baseTransformsPins.Add(pin);
        }
    }

    private int memoryScore;
    private string _baseText = "Overall score: ";
    private int attemp;

    private void FixedUpdate()
    {
        if (attemp == 2)
        {
            RestorePins();
        }
        
        if (score == 10)
        {
            _score1.text = "STRIKE!";
            _score2.text = score.ToString();
            _score3.text = (Int32.Parse(_score3.text) + score).ToString();
            memoryScore = 0;
            score = 0;
            attemp = 0;
        }
        else if (memoryScore + score == 10)
        {
            _score1.text = "SPARE!";
            _score2.text = score.ToString();
            _score3.text = (Int32.Parse(_score3.text) + score).ToString();
            memoryScore = 0;
            score = 0;
            attemp = 0;
        }
        else
        {
            _score1.text = "";
            _score2.text = score.ToString();
            _score3.text = (Int32.Parse(_score3.text) + score).ToString();
            memoryScore = score;
            score = 0;
            attemp += 1;
        }
    }

    private void RestorePins()
    {
        for (int i = 0; i < _transformsPins.Count; i++)
        {
            _transformsPins[i].transform.position = _baseTransformsPins[i].transform.position;
            _transformsPins[i].transform.rotation = _baseTransformsPins[i].transform.rotation;
            _transformsPins[i].gameObject.SetActive(true);
        }
    }

    public void RestartGame()
    {
        _score1.text = _score2.text = _score3.text = "0";
        RestorePins();
        FindObjectOfType<BowlingBall>().RestoreBall();
    }
}
