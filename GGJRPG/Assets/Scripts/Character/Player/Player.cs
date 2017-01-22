using UnityEngine;
using System.Collections;

[AddComponentMenu("Character/Player")]
public class Player : Character
{
    public new void Attack(Character target, Command atk)
    {
        base.Attack(target, atk);

        target.HP -= atk.amount;
        gm.AdvanceTurn();
    } // end Attack()

    public new void Magic(Character target, Command spell)
    {
        base.Magic(target, spell);

        target.HP -= spell.amount;
        gm.AdvanceTurn();
    } // end Magic()
}
