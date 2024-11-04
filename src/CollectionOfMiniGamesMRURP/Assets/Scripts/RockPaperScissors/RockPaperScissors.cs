using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using Random = UnityEngine.Random;

public class RockPaperScissors : MonoBehaviour
{
    [Header("AI")]
    [SerializeField] private List<GameObject> _variantsForAI;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _rockAnimationObject;

    [Header("Game")] 
    [SerializeField] private GameObject _startButton;
    [SerializeField] private TextMeshPro _score;
    [SerializeField] private TextMeshPro _result;
    [SerializeField] private TextMeshPro _choice;

    public bool _animationEnd;
    public bool _isStart;
    private GameObject _aiPickObject;
    private string _aiPick;
    private string _playerPick;

    private int _aiScore;
    private int _playerScore;

    private PlayerPick _playerPickScript;

    private void Awake()
    {
        _playerPickScript = FindAnyObjectByType<PlayerPick>().GetComponent<PlayerPick>();
        _animationEnd = false;
        _isStart = false;
    }

    public void StartGame()
    {
        try
        {
            _aiPickObject.SetActive(false);
        }
        finally
        {
            FindAnyObjectByType<PlayerPick>()._isPick = false;
            _isStart = true;
            _result.gameObject.SetActive(false);
            _choice.gameObject.SetActive(true);
            _rockAnimationObject.SetActive(true);
            _animator.SetBool("StartGame", true);
            _startButton.SetActive(false);
        }
    }

    private void Update()
    {
        if (_animationEnd)
        {
            _choice.gameObject.SetActive(false);
            _rockAnimationObject.SetActive(false);
            _aiPickObject = _variantsForAI[Random.Range(0, _variantsForAI.Count)];
            _aiPickObject.SetActive(true);
            _aiPick = _aiPickObject.tag;
            _animationEnd = false;
            
            _result.gameObject.SetActive(true);
            if (_aiPick == _playerPick)
            {
                _result.text = "Draw";
            }
            else if (_aiPick == "Paper")
            {
                if (_playerPick == "Rock")
                {
                    _result.text = "AI Win";
                    _score.text = $"Score {++_aiScore}:{_playerScore}";
                }
                else if (_playerPick == "Scissors")
                {
                    _result.text = "You Win";
                    _score.text = $"Score {_aiScore}:{++_playerScore}";
                }
            }
            else if (_aiPick == "Rock")
            {
                if (_playerPick == "Scissors")
                {
                    _result.text = "AI Win";
                    _score.text = $"Score {++_aiScore}:{_playerScore}";
                }
                else if (_playerPick == "Paper")
                {
                    _result.text = "You Win";
                    _score.text = $"Score {_aiScore}:{++_playerScore}";
                }
            }
            else if (_aiPick == "Scissors")
            {
                if (_playerPick == "Paper")
                {
                    _result.text = "AI Win";
                    _score.text = $"Score {++_aiScore}:{_playerScore}";
                }
                else if (_playerPick == "Rock")
                {
                    _result.text = "You Win";
                    _score.text = $"Score {_aiScore}:{++_playerScore}";
                }
            }
            _isStart = false;
            _startButton.SetActive(true);
        }
    }

    public void PlayerPick(string name)
    {
        _choice.gameObject.SetActive(false);
        _playerPick = name;
        _animator.SetBool("StartGame", false);
    }
}
