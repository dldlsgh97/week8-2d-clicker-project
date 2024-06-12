using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

    }

    [SerializeField] Text ScoreText;
    int _score;
    public void AddScore(int score)
    {
        _score += score;
        ScoreText.text = $"Score : {_score}";
    }
}
