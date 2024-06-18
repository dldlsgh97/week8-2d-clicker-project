using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    public void SaveData()
    {
        PlayerPrefs.SetInt("EnemyHP", GameManager.Instance.EnemyHp);
        PlayerPrefs.SetInt("PlayerAttackLevel", ClickManager.Instance.AttackLevel);
        PlayerPrefs.SetInt("Gold", GameManager.Instance.Gold);
        PlayerPrefs.SetInt("Player1Damage", PlayerManager.Instance.Player1.AttackDamage);
        PlayerPrefs.SetInt("Player2Damage", PlayerManager.Instance.Player2.AttackDamage);
        PlayerPrefs.SetInt("Player3Damage", PlayerManager.Instance.Player3.AttackDamage);
        PlayerPrefs.SetInt("Player4Damage", PlayerManager.Instance.Player4.AttackDamage);
        PlayerPrefs.Save();
        Debug.Log("Data Saved");
    }

    public void LoadData()
    {
        GameManager.Instance.EnemyHp = PlayerPrefs.GetInt("EnemyHP");
        ClickManager.Instance.AttackLevel = PlayerPrefs.GetInt("PlayerAttackLevel");
        GameManager.Instance.Gold = PlayerPrefs.GetInt("Gold");
        PlayerManager.Instance.Player1.AttackDamage = PlayerPrefs.GetInt("Player1Damage");
        PlayerManager.Instance.Player2.AttackDamage = PlayerPrefs.GetInt("Player2Damage");
        PlayerManager.Instance.Player3.AttackDamage = PlayerPrefs.GetInt("Player3Damage");
        PlayerManager.Instance.Player4.AttackDamage = PlayerPrefs.GetInt("Player4Damage");

        Debug.Log("Data Loaded");
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Data Deleted");
    }
}
