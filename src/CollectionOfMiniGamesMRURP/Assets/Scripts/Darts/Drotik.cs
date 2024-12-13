using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Drotik : MonoBehaviour
{

    public TextMeshPro _score;
    
    public void TextOnDrotik(int score)
    {
        _score.gameObject.SetActive(true);
        _score.text = score.ToString();
    }
    
    public void TextOnDrotik(string type)
    {
        _score.gameObject.SetActive(true);
        _score.text = type;
    }
    
}
