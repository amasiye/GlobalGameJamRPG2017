using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int maxHP = 9999;
    public int maxATK = 99;
    public int maxDEF = 99;
    protected int hp;
    protected int atk;
    protected int def;
    public int HP { get { return hp; } set { hp = Mathf.Clamp(value, 0, maxHP); } }
    public int ATK { get { return atk; } set { atk = Mathf.Clamp(value, 0, maxATK); } }
    public int DEF { get { return def; } set { def = Mathf.Clamp(value, 0, maxDEF); } }

    public Text hpText;

    public enum Element { Earth, Ice, Fire, Lightning }

    public Element bindHP = Element.Ice;
    public Element bindAtk = Element.Fire;
    public Element bindDef = Element.Earth;
    public Element bindMgk = Element.Lightning;

    [SerializeField]
    protected GameManager gm;

    void Awake()
    {
        if(!gm)
            gm = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<GameManager>();
    }

    void Update()
    {
        if(hpText)
        {
            hpText.text = hp.ToString();
        }
    } // end Update()

    public void Attack(Character target, Command atk)
    {
    } // end Attack()

    public void Magic(Character target, Command spell)
    {
    } // end Magic()
}
