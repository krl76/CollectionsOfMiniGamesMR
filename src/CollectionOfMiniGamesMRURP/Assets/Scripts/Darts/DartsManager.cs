using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DartsManager : MonoBehaviour
{
    [Header("Darts")]
    [SerializeField] private TextMeshPro _scoreTable;
    [SerializeField] private Transform _dartboardCenter;

    [Header("Audio")]
    [SerializeField] private AudioClip _ping;
    [SerializeField] private AudioClip _getRay;
    [SerializeField] private AudioClip _win;
    
    [Header("Other sets")]
    public List<DartsRay> _dartsRays;
    
    public int _score;
    public bool _isPing;
    
    private Arrow _arrow;
    private Drotik _drotik;
    
    private bool x2;
    private bool x3;

    private AudioSource _audioSource;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Enter");
        
        if (other.gameObject.CompareTag("Arrow"))
        {
            _audioSource.PlayOneShot(_ping);
            
            _arrow = other.gameObject.GetComponent<Arrow>();
            OffArrowGravity();
            
            _isPing = false;
            x2 = false;
            x3 = false;
            _score = 0;
            _drotik = other.gameObject.GetComponent<Drotik>();
            _drotik._score.gameObject.SetActive(false);
            
            
            Vector3 hitPoint = other.contacts[0].point;
            Vector3 dartboardCenter = _dartboardCenter.position;
    
            float distance = Vector3.Distance(hitPoint, dartboardCenter);
            Debug.LogError(distance);
    
            if (distance <= 0.016f)
            {
                _audioSource.PlayOneShot(_getRay);
                _score += 50;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                
                _drotik.TextOnDrotik(_score);
                
                return;
            }
            else if (distance <= 0.0297f)
            {
                _audioSource.PlayOneShot(_getRay);
                _score += 25;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                
                _drotik.TextOnDrotik(_score);
                
                return;
            }
            else if (distance >= 0.14f && distance <= 0.157f)
            {
                x3 = true;
                _isPing = true;
            }
            else if (distance >= 0.232f && distance <= 0.247f)
            {
                x2 = true;
                _isPing = true;
            }
            else if (distance >= 0.245f)
            {
                return;
            }
            else
            {
                _isPing = true;
            }
            
        }
    }

    private void OffArrowGravity()
    {
        _arrow.OffGravity();
    }

    public void Score(float angle)
    {
        if (angle >= 8 && angle < 26)
        {
            if (x2) _score += 1 * 2;
            if (x3) _score += 1 * 3;
            else _score += 1; 
            
            if (Int32.Parse(_scoreTable.text) - _score >= 0)
            {
                _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
            }
            Debug.Log("Попадание в сектор 1");
        }
        else if (angle >= 26 && angle < 44)
        {
            if (x2) _score += 18 * 2;
            if (x3) _score += 18 * 3;
            else _score += 18;
                
            if (Int32.Parse(_scoreTable.text) - _score >= 0)
            {
                _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
            }
            Debug.Log("Попадание в сектор 18");
        }
        else if (angle >= 44 && angle < 62)
        {
            if (x2) _score += 4 * 2;
            if (x3) _score += 4 * 3;
            else _score += 4;
                
            if (Int32.Parse(_scoreTable.text) - _score >= 0)
            {
                _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
            }
            Debug.Log("Попадание в сектор 4");
        }
        else if (angle >= 62 && angle < 80)
        {
            if (x2) _score += 13 * 2;
            if (x3) _score += 13 * 3;
            else _score += 13;
                
            if (Int32.Parse(_scoreTable.text) - _score >= 0)
            {
                _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
            }
            Debug.Log("Попадание в сектор 13");
        }
        else if (angle >= 80 && angle < 98)
        {
            if (x2) _score += 6 * 2;
            if (x3) _score += 6 * 3;
            else _score += 6;
                
            if (Int32.Parse(_scoreTable.text) - _score >= 0)
            {
                _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
            }
            Debug.Log("Попадание в сектор 6");
        }
        else if (angle >= 98 && angle < 116)
        {
            if (x2) _score += 10 * 2;
            if (x3) _score += 10 * 3;
            else _score += 10;
                
            if (Int32.Parse(_scoreTable.text) - _score >= 0)
            {
                _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
            }
            Debug.Log("Попадание в сектор 10");
        }
        else if (angle >= 116 && angle < 134)
        {
            if (x2) _score += 15 * 2;
            if (x3) _score += 15 * 3;
            else _score += 15;
                
            if (Int32.Parse(_scoreTable.text) - _score >= 0)
            {
                _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
            }
            Debug.Log("Попадание в сектор 15");
        }
        else if (angle >= 134 && angle < 152)
        {
            if (x2) _score += 2 * 2;
            if (x3) _score += 2 * 3;
            else _score += 2;
                
            if (Int32.Parse(_scoreTable.text) - _score >= 0)
            {
                _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
            }
            Debug.Log("Попадание в сектор 2");
        }
        else if (angle >= 152 && angle < 170)
        {
            if (x2) _score += 17 * 2;
            if (x3) _score += 17 * 3;
            else _score += 17;
                
            if (Int32.Parse(_scoreTable.text) - _score >= 0)
            {
                _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
            }
            Debug.Log("Попадание в сектор 17");
        }
        else if (angle >= 170 && angle < 188)
        {
            if (x2) _score += 3 * 2;
            if (x3) _score += 3 * 3;
            else _score += 3;
                
            if (Int32.Parse(_scoreTable.text) - _score >= 0)
            {
                _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
            }
            Debug.Log("Попадание в сектор 3");
        }
        else if (angle >= 188 && angle < 206)
        {
            if (x2) _score += 19 * 2;
            if (x3) _score += 19 * 3;
            else _score += 19;
                
            if (Int32.Parse(_scoreTable.text) - _score >= 0)
            {
                _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
            }
            Debug.Log("Попадание в сектор 19");
        }
        else if (angle >= 206 && angle < 224)
        {
            if (x2) _score += 7 * 2;
            if (x3) _score += 7 * 3;
            else _score += 7;
                
            if (Int32.Parse(_scoreTable.text) - _score >= 0)
            {
                _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
            }
            Debug.Log("Попадание в сектор 7");
        }
        else if (angle >= 224 && angle < 242)
        {
            if (x2) _score += 16 * 2;
            if (x3) _score += 16 * 3;
            else _score += 16;
                
            if (Int32.Parse(_scoreTable.text) - _score >= 0)
            {
                _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
            }
            Debug.Log("Попадание в сектор 16");
        }
        else if (angle >= 242 && angle < 260)
        {
            if (x2) _score += 8 * 2;
            if (x3) _score += 8 * 3;
            else _score += 8;
                
            if (Int32.Parse(_scoreTable.text) - _score >= 0)
            {
                _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
            }
            Debug.Log("Попадание в сектор 8");
        }
        else if (angle >= 260 && angle < 278)
        {
            if (x2) _score += 11 * 2;
            if (x3) _score += 11 * 3;
            else _score += 11;
                
            if (Int32.Parse(_scoreTable.text) - _score >= 0)
            {
                _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
            }
            Debug.Log("Попадание в сектор 11");
        }
        else if (angle >= 278 && angle < 296)
        {
            if (x2) _score += 14 * 2;
            if (x3) _score += 14 * 3;
            else _score += 14;
                
            if (Int32.Parse(_scoreTable.text) - _score >= 0)
            {
                _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
            }
            Debug.Log("Попадание в сектор 14");
        }
        else if (angle >= 296 && angle < 314)
        {
            if (x2) _score += 9 * 2;
            if (x3) _score += 9 * 3;
            else _score += 9;
                
            if (Int32.Parse(_scoreTable.text) - _score >= 0)
            {
                _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
            }
            Debug.Log("Попадание в сектор 9");
        }
        else if (angle >= 314 && angle < 332)
        {
            if (x2) _score += 12 * 2;
            if (x3) _score += 12 * 3;
            else _score += 12;
                
            if (Int32.Parse(_scoreTable.text) - _score >= 0)
            {
                _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
            }
            Debug.Log("Попадание в сектор 12");
        }
        else if (angle >= 332 && angle < 350)
        {
            if (x2) _score += 5 * 2;
            if (x3) _score += 5 * 3;
            else _score += 5;
                
            if (Int32.Parse(_scoreTable.text) - _score >= 0)
            {
                _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
            }
            Debug.Log("Попадание в сектор 5");
        }
        else
        {
            if (x2) _score += 20 * 2;
            if (x3) _score += 20 * 3;
            else _score += 20;
                
            if (Int32.Parse(_scoreTable.text) - _score >= 0)
            {
                _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
            }
            Debug.Log("Попадание в сектор 20");
        }

        if (Int32.Parse(_scoreTable.text) == 0)
        {
            FindAnyObjectByType<Win>().ActivateMenu();
        }
        
        _drotik.TextOnDrotik(_score);
    }
    
}
