using UnityEngine;
using System.Collections;

public class Player : Character
{
    public new void Attack(Character target, Command atk)
    {
        Debug.Log(atk.name);
        target.HP -= atk.amount;
    } // end Attack()

    public new void Magic(Character target, Command atk)
    {
        target.HP -= 5;
    } // end Magic()
}
