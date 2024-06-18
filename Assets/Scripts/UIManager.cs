using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] TMP_Text HpText;
    [SerializeField] TMP_Text GoldText;
    [SerializeField] Slider HpBar;
    [SerializeField] TMP_Text AutoClickBtnText;
    [SerializeField] TMP_Text AttackUpBtnText;
    [SerializeField] TMP_Text AttackStatText;
    [SerializeField] Button LoadBtn;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

    }
    private void Start()
    {
        GameManager.Instance.Gold = 0;
    }
    public void UpdateUI()
    {
        UpdateHPUI();
        UpdateGoldUI();
        UpdateBtn();
        UpdateStatUI();
        CheckLoadData();


    }

    void UpdateHPUI()
    {       
        HpBar.value = (float)GameManager.Instance.EnemyHp / GameManager.Instance.EnemyMaxHp;
        HpText.text = $"HP : {GameManager.Instance.EnemyHp}/{GameManager.Instance.EnemyMaxHp}";      
    }

    void UpdateGoldUI()
    {
        GoldText.text = $"{GameManager.Instance.Gold} G";
    }    

    void UpdateBtn()
    {
        ClickManager.Instance.UpdateUpgradeCost();
        AttackUpBtnText.text = $"Attack Cost:{ClickManager.Instance.AttackUpCost}";
    }

    void UpdateStatUI()
    {
        AttackStatText.text = $"Attack Damage : {PlayerManager.Instance.Player1.AttackDamage}";
    }

    public void OnSaveBtnClick()
    {
        DataManager.Instance.SaveData();
        LoadBtn.interactable = true;
    }
    void CheckLoadData()
    {
        if (PlayerPrefs.HasKey("EnemyHP") || PlayerPrefs.HasKey("PlayerAttackLevel") || PlayerPrefs.HasKey("Gold"))
        {
            LoadBtn.interactable = true;
        }
        else
        {
            LoadBtn.interactable = false;
        }
    }
    public void OnLoadBtnClick()
    {
        DataManager.Instance.LoadData();
        UpdateUI();
    }
    public void OnDeleteBtnClick()
    {
        DataManager.Instance.DeleteData();
        CheckLoadData();
    }
}
