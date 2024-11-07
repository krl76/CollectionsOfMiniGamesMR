using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PutInBox : MonoBehaviour
{

   [SerializeField] private List<Transform> _spawnPoints;
   [SerializeField] private TextMeshPro _score;
   [SerializeField] private TextMeshPro _timer;

   [Header("Timer")] 
   [SerializeField] private int minutes;
   [SerializeField] private int seconds;

   private int _countInBox = 0;
   private bool _isLost;

   private Lost _lost;

   private void Awake()
   {
      _score.text = $"0/{_spawnPoints.Count}";
      if(seconds < 10) _timer.text = $"Estimate time: {minutes}:0{seconds}";
      else _timer.text = $"Estimate time: {minutes}:{seconds}";
   }

   private void Start()
   {
      _lost = FindAnyObjectByType<Lost>();
      StartCoroutine(Timer());
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Bottle"))
      {
         other.transform.position = _spawnPoints[_countInBox++].transform.position;
         other.transform.rotation = new Quaternion(90, 0, 0, 0);
         _score.text = $"{_countInBox}/{_spawnPoints.Count}";
         if (_countInBox == _spawnPoints.Count)
         {
            _lost.ActivateWindow(false);
         }
      }
   }

   private void Update()
   {
      if (_isLost && !_lost._isMenu)
      {
         _lost.ActivateWindow(_isLost);
      }
   }

   private IEnumerator Timer()
   {
      while (!_isLost)
      {
         yield return new WaitForSeconds(1);
         if (seconds == 0)
         {
            minutes--;
            seconds = 59;
         }
         else seconds--;

         var realtime = seconds + minutes * 60;
         if (realtime <= 0)
         {
            _isLost = true;
         }
         if(seconds < 10) _timer.text = $"Estimate time: {minutes}:0{seconds}";
         else _timer.text = $"Estimate time: {minutes}:{seconds}";
      }
   }
}
