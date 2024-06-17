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

        UpdateUI();
    }
    public void UpdateUI()
    {
        UpdateHPUI();
        UpdateGoldUI();
        UpdateBtn();
        UpdateStatUI();
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
        AttackUpBtnText.text = $"Attack Cost:{ClickManager.Instance.AttackUpCost}";
    }

    void UpdateStatUI()
    {
        AttackStatText.text = $"Attack Damage : {PlayerManager.Instance.Player1.AttackDamage}";
    }
}
