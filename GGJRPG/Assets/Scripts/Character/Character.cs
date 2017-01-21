using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Character : MonoBehaviour
{
    public float hp;
    public float atk;
    public float def;

    public Text hpText;

    public enum Element { Earth, Ice, Fire, Lightning }

    public void Update()
    {
        if(hpText)
        {
            hpText.text = hp.ToString();
        }
    } // end Update()

    public void Attack(Character target)
    {
    } // end Attack()

    public void Magic(Character target)
    {
    } // end Magic()
}
