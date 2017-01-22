using UnityEngine;
using System.Collections;

[AddComponentMenu("Character/Enemy")]
public class Enemy : Character
{
    void Awake()
    {
        int val = Random.Range(1, 5);
        maxHP = maxHP * val;
    }

    public new void Attack(Character target, Command atk)
    {
        base.Attack(target, atk);
        target.Damage(atk.amount);
    } // end Attack()
}
