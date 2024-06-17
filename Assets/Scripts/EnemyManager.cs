using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int MaxHP;
    public int HP;
    public float HPBarValue;
    public static EnemyManager Instance;
    public GameObject[] Gems;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        MaxHP = 10000;
        HP = MaxHP;
    }
    void Update()
    {
        
    }

    public void GetDamage(int damage)
    {
        HP -= damage;
        HPBarValue = (float)HP / MaxHP;
        DropGem();
        UIManager.Instance.UpdateHPUI();
    }

    void DropGem()
    {
        if(HP % 100 == 0)
        {
            float randNum = Random.value;
            if (randNum <= 0.7f)
            {
                Instantiate(Gems[0]);
            }
            else if (randNum <= 0.87f)
            {
                Instantiate(Gems[1]);
            }
            else if (randNum <= 0.95f)
            {
                Instantiate(Gems[2]);
            }
            else if (randNum <= 0.99f)
            {
                Instantiate(Gems[3]);
            }
            else
            {
                Instantiate(Gems[4]);
            }
        }
        
    }
}
