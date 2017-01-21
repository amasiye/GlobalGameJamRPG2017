using UnityEngine;
using System.Collections;

public class Player : Character
{
    public new void Attack(Character target, Command atk)
    {
        switch(bindAtk)
        {
            case Element.Fire:
                // Deplete the Mana pool
                gm.Fire -= atk.cost;
                // Adjust the multiplier
                break;
            case Element.Ice:
                // Deplete the Mana pool
                gm.Ice -= atk.cost;
                // Adjust the multiplier
                break;
            case Element.Lightning:
                // Deplete the Mana pool
                gm.Lightning -= atk.cost;
                // Adjust the multiplier
                break;
            case Element.Earth:
                // Deplete the Mana pool
                gm.Earth -= atk.cost;
                // Adjust the multiplier
                break;
        }
        target.HP -= atk.amount;
        gm.AdvanceTurn();
    } // end Attack()

    public new void Magic(Character target, Command atk)
    {
        target.HP -= 5;
        gm.AdvanceTurn();
    } // end Magic()
}
