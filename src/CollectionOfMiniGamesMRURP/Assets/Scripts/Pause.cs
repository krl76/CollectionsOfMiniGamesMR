using System;
using System.Collections;
using System.Collections.Generic;
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
