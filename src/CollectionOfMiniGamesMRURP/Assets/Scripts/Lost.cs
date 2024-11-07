using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lost : MonoBehaviour
{
    [SerializeField] private GameObject _windowGo;
    [SerializeField] private string _nameOfMenu;

    [Header("UI")] 
    [SerializeField] private TextMeshPro _resultText;

    public bool _isMenu;
    
    private void OnEnable()
    {
        GetComponent<ReturnObject>().StartCoroutine(GetComponent<ReturnObject>().SnapCanvasInFrontOfCamera());
    }
    
    public void ActivateWindow(bool isLost)
    {
        if (isLost) _resultText.text = "You are lost";
        else _resultText.text = "You are win";
        
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
