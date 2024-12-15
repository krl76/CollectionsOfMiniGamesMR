using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip _click;

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
    
    public void LoadScene(string game)
    {
        SceneManager.LoadScene(game);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
    
}
