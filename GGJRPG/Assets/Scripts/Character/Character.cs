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

    public AudioClip attackSound;
    public AudioSource source;

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
        if(attackSound)
        {
            source.clip = attackSound;

            if(!source.isPlaying)
            {
                source.Play();
            }
        }
        UpdateManaPool(bindAtk, atk);
    } // end Attack()

    public void Magic(Character target, Command spell)
    {
        UpdateManaPool(bindAtk, spell);
    } // end Magic()

    public void UpdateManaPool(Element elm, Command cmd)
    {

        switch(elm)
        {
            case Element.Fire:
                gm.Fire -= cmd.cost;
                gm.Ice += cmd.cost;
                // Adjust the multiplier
                break;
            case Element.Ice:
                gm.Ice -= cmd.cost;
                gm.Fire += cmd.cost;
                // Adjust the multiplier
                break;
            case Element.Lightning:
                gm.Lightning -= cmd.cost;
                gm.Earth += cmd.cost;
                // Adjust the multiplier
                break;
            case Element.Earth:
                gm.Earth -= cmd.cost;
                gm.Lightning += cmd.cost;
                // Adjust the multiplier
                break;
        }
    } // end UpdateManaPool()

    public void Damage(int amount)
    {
        HP -= amount;

        if(HP < 1)
        {
            gm.ChangeGameState(GameManager.GameState.GameOver);
        }
        gm.AdvanceTurn();
    } // end Damage()
}
