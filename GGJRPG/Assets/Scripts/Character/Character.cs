using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[AddComponentMenu("Character/Character")]
public class Character : MonoBehaviour
{
    public int maxHP = 9999;
    public int maxATK = 99;
    public int maxDEF = 99;
    protected int hp;
    protected int atk;
    protected int def;
    public int HP
    {
        get
        {
            return hp;
        }

        set
        {
            hp = Mathf.Clamp(value, 0, maxHP);
            if (healthDisplay != null)
            {
                healthDisplay.SetHP(hp, true);
            }
        }
    }

    public int ATK { get { return atk; } set { atk = Mathf.Clamp(value, 0, maxATK); } }
    public int DEF { get { return def; } set { def = Mathf.Clamp(value, 0, maxDEF); } }

    public HealthBar healthDisplay;
    public Color damageColor = new Color(.8f, 0, 0);

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

    void Start()
    {
        hp = maxHP;
        if (healthDisplay != null)
        {
            healthDisplay.BarMax = maxHP;
            healthDisplay.SetHP(hp, false);
        }
    }

    public void Attack(Character target, Command atk)
    {
        switch(bindAtk)
        {
            case Element.Fire:
                gm.Fire -= atk.cost;
                // Adjust the multiplier
                break;
            case Element.Ice:
                gm.Ice -= atk.cost;
                // Adjust the multiplier
                break;
            case Element.Lightning:
                gm.Lightning -= atk.cost;
                // Adjust the multiplier
                break;
            case Element.Earth:
                gm.Earth -= atk.cost;
                // Adjust the multiplier
                break;
        }
    } // end Attack()

    public void Magic(Character target, Command spell)
    {
    } // end Magic()
}
