using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public Player Player1;
    public Player Player2;
    public Player Player3;
    public Player Player4;

    public void PlayerAttack()
    {
        Player1.Attack();
        Player2.Attack();
        Player3.Attack();
        Player4.Attack();
    }
    public void StopPlayerAttack()
    {
        Player1.StopAttack();
        Player2.StopAttack();
        Player3.StopAttack();
        Player4.StopAttack();
    }

    public void PlayerAttackUp(int num)
    {
        Player1.AttackDamageUp(num);
        Player2.AttackDamageUp(num);
        Player3.AttackDamageUp(num);
        Player4.AttackDamageUp(num);
    }
}
