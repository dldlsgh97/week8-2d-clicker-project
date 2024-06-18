using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator _playerAnim;
    public int AttackDamage = 10;
    private void Start()
    {
        _playerAnim = GetComponent<Animator>();
    }

    public void Attack()
    {
        _playerAnim.SetBool("Attack",true);
        EnemyManager.Instance.GetDamage(AttackDamage);
        AudioManager.Instance.SlashSound();
    }

    public void StopAttack()
    {
        _playerAnim.SetBool("Attack", false);
    }

    public void AttackDamageUp(int num)
    {
        AttackDamage += num;
    }
}
