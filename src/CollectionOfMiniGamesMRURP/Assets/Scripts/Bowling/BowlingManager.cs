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

    private Vector3[] _baseVector3Pins;
    private Quaternion[] _baseRotPins;

    private void Start()
    {
        _baseVector3Pins = new Vector3[_objectPins.Count];
        _baseRotPins = new Quaternion[_objectPins.Count];
        
        int i = 0;
        foreach (var pin in _objectPins)
        {
            _baseVector3Pins[i] = pin.transform.position;
            _baseRotPins[i] = pin.transform.rotation;
            i++;
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
            _score1.gameObject.SetActive(true);
            _score2.text = score.ToString();
            _score2.gameObject.SetActive(true);
            _score3.text = (Int32.Parse(_score3.text) + score).ToString();
            memoryScore = 0;
            score = 0;
            attemp = 0;
        }
        else if (memoryScore + score == 10)
        {
            _score1.text = "SPARE!";
            _score1.gameObject.SetActive(true);
            _score2.text = score.ToString();
            _score2.gameObject.SetActive(true);
            _score3.text = (Int32.Parse(_score3.text) + score).ToString();
            memoryScore = 0;
            score = 0;
            attemp = 0;
        }
        else
        {
            _score1.text = "";
            _score2.text = score.ToString();
            _score2.gameObject.SetActive(true);
            _score3.text = (Int32.Parse(_score3.text) + score).ToString();
            memoryScore = score;
            score = 0;
            attemp += 1;
        }
    }

    private void RestorePins()
    {
        for (int i = 0; i < _objectPins.Count; i++)
        {
            _objectPins[i].transform.position = _baseVector3Pins[i];
            _objectPins[i].transform.rotation = _baseRotPins[i];
            _objectPins[i].SetActive(true);
        }
    }

    public void RestartGame()
    {
        _score1.text = _score2.text = _score3.text = "0";
        RestorePins();
        FindObjectOfType<BowlingBall>().RestoreBall(true);
    }
    
    public void NewAttemp()
    {
        _score1.gameObject.SetActive(false);
        _score2.gameObject.SetActive(false);
    }
}
