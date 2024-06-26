using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public enum GemType
    {
        Silver = 1,
        Yellow = 3,
        Blue = 5,
        Green = 7,
        Red = 10
    }
    [SerializeField] GemType type;
    void Start()
    {
        GetGem();
    }

    void GetGem()
    {
        GameManager.Instance.Gold += (int)type;
        UIManager.Instance.UpdateUI();
        AudioManager.Instance.CoinSound();
        Destroy(gameObject, 1f);
    }

}
