using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private string _nameOfMenu;
    [SerializeField] private GameObject _menu;

    private bool _isOpen = false;

    private void Awake()
    {
        _isOpen = false;
    }

    private void OnEnable()
    {
        GetComponent<ReturnObject>().StartCoroutine(GetComponent<ReturnObject>().SnapCanvasInFrontOfCamera());
    }

    public void ActivateMenu()
    {
        if (!_isOpen)
        {
            _menu.SetActive(true);
            //Time.timeScale = 0;
            _isOpen = true;
        }
        else
        {
            _menu.SetActive(false);
            //Time.timeScale = 1;
            _isOpen = false;
        }
    }
    
    public void ToMainMenu()
    {
        SceneManager.LoadScene(_nameOfMenu);
    }
}
