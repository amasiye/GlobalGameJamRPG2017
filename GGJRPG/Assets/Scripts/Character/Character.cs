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

    public void Start()
    {
        if(hpText)
        {
            hpText.text = hp.ToString();
        }
    } // end Start()

    public void Attack(Character target)
    {

    }

    public void Magic(Character target)
    {

    }
}
