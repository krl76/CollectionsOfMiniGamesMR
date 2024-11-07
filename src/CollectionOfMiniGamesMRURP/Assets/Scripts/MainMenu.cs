using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    private void OnEnable()
    {
        GetComponent<ReturnObject>().StartCoroutine(GetComponent<ReturnObject>().SnapCanvasInFrontOfCamera());
    }
    
    public void LoadScene(string game)
    {
        SceneManager.LoadScene(game);
    }
    
    public void Exit()
    {
        Debug.LogWarning("Exit");
        Application.Quit();
    }
    
}
