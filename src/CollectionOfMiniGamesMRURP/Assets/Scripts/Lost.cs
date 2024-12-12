using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lost : MonoBehaviour
{
    [SerializeField] private GameObject _windowGo;
    [SerializeField] private string _nameOfMenu;
    
    [Header("Audio")]
    [SerializeField] private AudioClip _win;
    [SerializeField] private AudioClip _lose;
    [SerializeField] private AudioClip _click;

    [Header("UI")] 
    [SerializeField] private TextMeshPro _resultText;

    public bool _isMenu;

    private AudioSource _audioSource;
    
    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        GetComponent<ReturnObject>().StartCoroutine(GetComponent<ReturnObject>().SnapCanvasInFrontOfCamera());
    }

    public void Click()
    {
        _audioSource.PlayOneShot(_click);
    }
    
    public void ActivateWindow(bool isLost)
    {
        if (isLost)
        {
            _audioSource.PlayOneShot(_lose);
            _resultText.text = "You are lost";
        }
        else
        {
            _audioSource.PlayOneShot(_win);
            _resultText.text = "You are win";
        }
        
        _isMenu = true;
        _windowGo.SetActive(true);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(_nameOfMenu);
    }
}
