using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartsManager : MonoBehaviour
{
    public int _score;
    public bool _isPing;

    private Arrow _arrow;

    private void Start()
    {
        _arrow = FindAnyObjectByType<Arrow>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Enter");
        if (other.gameObject.CompareTag("Arrow"))
        {
            OffArrowGravity();
            Vector3 hitPoint = other.contacts[0].point;
            Vector3 dartboardCenter = transform.position; // Центр доски
    
            float distance = Vector3.Distance(hitPoint, dartboardCenter);
            Debug.Log(distance);
    
            if (distance <= 0.042f) // Радиус центральной зоны
            {
                _score += 50;
                return;
            }
            else if (distance <= 0.11f) // Радиус следующей зоны
            {
                _score += 25;
                return;
            }

            Vector3 direction = hitPoint - dartboardCenter;
            float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

            if (angle < 0) angle += 360; // Привести угол к диапазону 0–360
    
            if (angle >= 0 && angle < 30)
                Debug.Log("Попадание в сектор 1");
            else if (angle >= 30 && angle < 60)
                Debug.Log("Попадание в сектор 2");
            Debug.Log(angle);
            
        }
    }

    private void OffArrowGravity()
    {
        _arrow.OffGravity();
    }

    
}
