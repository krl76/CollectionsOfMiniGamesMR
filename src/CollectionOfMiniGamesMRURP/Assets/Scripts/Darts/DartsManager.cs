using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DartsManager : MonoBehaviour
{
    [SerializeField] private TextMeshPro _scoreTable;
    
    public int _score;
    public bool _isPing;

    private Arrow _arrow;
    private bool x2;
    private bool x3;

    private void Start()
    {
        _arrow = FindAnyObjectByType<Arrow>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Enter");
        
        if (other.gameObject.CompareTag("Arrow"))
        {
            x2 = false;
            x3 = false;
            _score = 0;
            other.gameObject.GetComponent<Drotik>()._score.gameObject.SetActive(false);
            
            OffArrowGravity();
            Vector3 hitPoint = other.contacts[0].point;
            Vector3 dartboardCenter = transform.position;
    
            float distance = Vector3.Distance(hitPoint, dartboardCenter);
    
            if (distance <= 0.042f)
            {
                _score += 50;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                
                other.gameObject.GetComponent<Drotik>().TextOnDrotik(_score);
                
                return;
            }
            else if (distance <= 0.11f)
            {
                _score += 25;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                
                other.gameObject.GetComponent<Drotik>().TextOnDrotik(_score);
                
                return;
            }
            else if (distance >= 0.68f && distance <= 0.76f)
            {
                x3 = true;
            }
            else if (distance >= 1.134f && distance <= 1.21f)
            {
                x2 = true;
            }
            else if (distance >= 1.215f)
            {
                return;
            }
            
            
            Debug.LogError(distance);

            Vector3 direction = hitPoint - dartboardCenter;
            float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

            if (angle < 0) angle += 360;

            if (angle >= 9 && angle < 27)
            {
                if (x2) _score += 8 * 2;
                if (x3) _score += 8 * 3;
                else _score += 8;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                Debug.Log("Попадание в сектор 8");
            }
            else if (angle >= 27 && angle < 45)
            {
                if (x2) _score += 16 * 2;
                if (x3) _score += 16 * 3;
                else _score += 16;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                Debug.Log("Попадание в сектор 16");
            }
            else if (angle >= 45 && angle < 63)
            {
                if (x2) _score += 7 * 2;
                if (x3) _score += 7 * 3;
                else _score += 7;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                Debug.Log("Попадание в сектор 7");
            }
            else if (angle >= 63 && angle < 81)
            {
                if (x2) _score += 19 * 2;
                if (x3) _score += 19 * 3;
                else _score += 19;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                Debug.Log("Попадание в сектор 19");
            }
            else if (angle >= 81 && angle < 99)
            {
                if (x2) _score += 3 * 2;
                if (x3) _score += 3 * 3;
                else _score += 3;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                Debug.Log("Попадание в сектор 3");
            }
            else if (angle >= 99 && angle < 117)
            {
                if (x2) _score += 17 * 2;
                if (x3) _score += 17 * 3;
                else _score += 17;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                Debug.Log("Попадание в сектор 17");
            }
            else if (angle >= 117 && angle < 135)
            {
                if (x2) _score += 2 * 2;
                if (x3) _score += 2 * 3;
                else _score += 2;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                Debug.Log("Попадание в сектор 2");
            }
            else if (angle >= 135 && angle < 153)
            {
                if (x2) _score += 2 * 2;
                if (x3) _score += 2 * 3;
                else _score += 2;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                Debug.Log("Попадание в сектор 15");
            }
            else if (angle >= 153 && angle < 171)
            {
                if (x2) _score += 10 * 2;
                if (x3) _score += 10 * 3;
                else _score += 10;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                Debug.Log("Попадание в сектор 10");
            }
            else if (angle >= 171 && angle < 189)
            {
                if (x2) _score += 6 * 2;
                if (x3) _score += 6 * 3;
                else _score += 6;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                Debug.Log("Попадание в сектор 6");
            }
            else if (angle >= 189 && angle < 207)
            {
                if (x2) _score += 13 * 2;
                if (x3) _score += 13 * 3;
                else _score += 13;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                Debug.Log("Попадание в сектор 13");
            }
            else if (angle >= 207 && angle < 225)
            {
                if (x2) _score += 4 * 2;
                if (x3) _score += 4 * 3;
                else _score += 4;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                Debug.Log("Попадание в сектор 4");
            }
            else if (angle >= 225 && angle < 243)
            {
                if (x2) _score += 18 * 2;
                if (x3) _score += 18 * 3;
                else _score += 18;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                Debug.Log("Попадание в сектор 18");
            }
            else if (angle >= 243 && angle < 261)
            {
                if (x2) _score += 1 * 2;
                if (x3) _score += 1 * 3;
                else _score += 1;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                Debug.Log("Попадание в сектор 1");
            }
            else if (angle >= 261 && angle < 279)
            {
                if (x2) _score += 20 * 2;
                if (x3) _score += 20 * 3;
                else _score += 20;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                Debug.Log("Попадание в сектор 20");
            }
            else if (angle >= 279 && angle < 297)
            {
                if (x2) _score += 5 * 2;
                if (x3) _score += 5 * 3;
                else _score += 5;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                Debug.Log("Попадание в сектор 5");
            }
            else if (angle >= 297 && angle < 315)
            {
                if (x2) _score += 12 * 2;
                if (x3) _score += 12 * 3;
                else _score += 12;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                Debug.Log("Попадание в сектор 12");
            }
            else if (angle >= 315 && angle < 333)
            {
                if (x2) _score += 9 * 2;
                if (x3) _score += 9 * 3;
                else _score += 9;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                Debug.Log("Попадание в сектор 9");
            }
            else if (angle >= 333 && angle < 351)
            {
                if (x2) _score += 14 * 2;
                if (x3) _score += 14 * 3;
                else _score += 14;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                Debug.Log("Попадание в сектор 14");
            }
            else
            {
                if (x2) _score += 11 * 2;
                if (x3) _score += 11 * 3;
                else _score += 11;
                
                if (Int32.Parse(_scoreTable.text) - _score > 0)
                {
                    _scoreTable.text = (Int32.Parse(_scoreTable.text) - _score).ToString();
                }
                Debug.Log("Попадание в сектор 11");
            }
            
            other.gameObject.GetComponent<Drotik>().TextOnDrotik(_score);
            
        }
    }

    private void OffArrowGravity()
    {
        _arrow.OffGravity();
    }

    
}
