using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float HPBarValue;
    public static EnemyManager Instance;
    public GameObject[] Gems;
    Animator _enemy_Anim;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        GameManager.Instance.EnemyMaxHp = 1000000000;
        GameManager.Instance.EnemyHp = GameManager.Instance.EnemyMaxHp;
        _enemy_Anim = GetComponent<Animator>();
        UIManager.Instance.UpdateUI();
    }
    void Update()
    {
        if(GameManager.Instance.EnemyHp <= 0)
        {
            GameManager.Instance.EnemyHp = 0;
            StopDamage();
            _enemy_Anim.SetTrigger("isDie");
        }
    }

    public void GetDamage(int damage)
    {
        GameManager.Instance.EnemyHp -= damage;
        DropGem();
        UIManager.Instance.UpdateUI();
        _enemy_Anim.SetBool("GetDamage", true);
        AudioManager.Instance.HitSound();
    }
    public void StopDamage()
    {
       _enemy_Anim.SetBool("GetDamage", false);
    }

    void DropGem()
    {
        if(GameManager.Instance.EnemyHp % 100 == 0)
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
