using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private string _nameOfMenu;
    [SerializeField] private GameObject _menu;
    [SerializeField] private AudioClip _click;

    private bool _isOpen = false;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _isOpen = false;
    }

    private void OnEnable()
    {
        GetComponent<ReturnObject>().StartCoroutine(GetComponent<ReturnObject>().SnapCanvasInFrontOfCamera());
    }

    public void Click()
    {
        _audioSource.PlayOneShot(_click);
    }

    public void ActivateMenu()
    {
        if (!_isOpen)
        {
            _menu.SetActive(true);
            _isOpen = true;
        }
        else
        {
            _menu.SetActive(false);
            _isOpen = false;
        }
    }
    
    public void ToMainMenu()
    {
        SceneManager.LoadScene(_nameOfMenu);
    }
}
