using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] private AudioClip _click;
    [SerializeField] private string _nameOfMenu;
    [SerializeField] private GameObject _winGO;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void ActivateMenu()
    {
        _winGO.SetActive(true);
        GetComponent<ReturnObject>().CanvasInFrontOfCamera();
    }

    public void Click()
    {
        _audioSource.PlayOneShot(_click);
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
