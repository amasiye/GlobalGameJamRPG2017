using UnityEngine;
using System.Collections;

[AddComponentMenu("Character/Enemy")]
public class Enemy : Character
{
    public new void Attack(Character target, Command atk)
    {
        Debug.Log(atk.name);
        target.HP -= atk.amount;
        gm.AdvanceTurn();
    } // end Attack()
}
