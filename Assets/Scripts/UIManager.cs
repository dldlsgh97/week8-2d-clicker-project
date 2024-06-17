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
    public int Gold;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

    }
    private void Start()
    {
        Gold = 0;
    }

    public void UpdateHPUI()
    {       
        HpBar.value = EnemyManager.Instance.HPBarValue;
        HpText.text = $"HP : {EnemyManager.Instance.HP}/{EnemyManager.Instance.MaxHP}";      
    }

    public void UpdateGoldUI()
    {

        GoldText.text = $"{Gold} G";
    }

    
}
