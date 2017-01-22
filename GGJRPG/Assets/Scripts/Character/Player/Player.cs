using UnityEngine;
using System.Collections;

[AddComponentMenu("Character/Player")]
public class Player : Character
{
    public new void Attack(Character target, Command atk)
    {
        base.Attack(target, atk);
        int amount = atk.amount;
        target.Damage(amount);
    } // end Attack()

    public new void Magic(Character target, Command spell)
    {
        base.Magic(target, spell);
        int amount = spell.amount;
        target.Damage(amount);
    } // end Magic()
}
