using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
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
   private bool win;
   private int temp_id;

   private int _amount_bottles;

   private Lost _lost;

   private void Awake()
   {
      temp_id = 0;
      
      _amount_bottles = FindObjectOfType<BottlesSpawn>().ActivateSpawn();

      if (_amount_bottles <= 5)
      {
         minutes = 1;
         seconds = 30;
      }
      else if (_amount_bottles <= 10)
      {
         minutes = 2;
         seconds = 45;
      }
      else
      {
         minutes = 4;
         seconds = 15;
      }

      _score.text = $"0/{_amount_bottles}";
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
      if (other.CompareTag("Bottle") && temp_id != other.GetInstanceID())
      {
         temp_id = other.GetInstanceID();

         other.GetComponent<Grabbable>().enabled = false;
         other.GetComponent<HandGrabInteractable>().enabled = false;
         other.GetComponent<GrabInteractable>().enabled = false;
         
         other.transform.SetParent(transform);
         other.transform.localScale = new Vector3(3, 3, 3);
         other.transform.localPosition = _spawnPoints[_countInBox++].transform.localPosition;
         //other.transform.localEulerAngles = new Vector3(90, 0, 0);
         
         _score.text = $"{_countInBox}/{_spawnPoints.Count}";
         
         if (_countInBox == _amount_bottles)
         {
            win = true;
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
      while (!_isLost || !win)
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
