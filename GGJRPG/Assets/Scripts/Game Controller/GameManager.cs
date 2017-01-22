using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Game Controller/Game Manager")]
public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;

    public int playerHP = 1000;
    public int enemyHP = 10000;

    [SerializeField]
    private int fire = 50;
    [SerializeField]
    private int lightning = 50;
    [SerializeField]
    private int ice = 50;
    [SerializeField]
    private int earth = 50;

    public int Fire { get { return fire; } set { fire = Mathf.Clamp(value, 0, 100); } }
    public int Lightning { get { return lightning; } set { lightning = Mathf.Clamp(value, 0, 100); } }
    public int Ice { get { return ice; } set { ice = Mathf.Clamp(value, 0, 100); } }
    public int Earth { get { return earth; } set { earth = Mathf.Clamp(value, 0, 100); } }

    public Character[] characters;
    [SerializeField]
    private int turnIndex;
    public int TurnIndex { get { return turnIndex; } set { turnIndex = (value > characters.Length - 1) ? 0 : value; } }

    public UIManager uim;

    public enum GameState { GameInit, GameStart, GameResume, GamePause, GameOver }
    public static GameState gameState;

    public enum BattleState { Ready, Acting }

    void Awake()
    {
        if(!uim)
            uim = GetComponent<UIManager>();

        if(!player)
            player = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Player>();

        if(!enemy)
            enemy = GameObject.FindGameObjectWithTag(Tags.enemy).GetComponent<Enemy>();

        Fire = Random.Range(25, 75);
        Ice = 100 - Fire;
        Lightning = Random.Range(25, 75);
        Earth = 100 - Lightning;

        player.HP = playerHP;
        enemy.HP = enemyHP;
    } // end Awake()

    void Start()
    {
        ChangeGameState(GameState.GameInit);
    } // end Start()

    void Update()
    {
        // Player Commands
        switch(turnIndex)
        {
            case 0:
                if(Input.GetButtonDown(ButtonManager.attack))
                {
                    player.Attack(enemy, CommandList.slash);
                }

                // Magic
                if(Input.GetButtonDown(ButtonManager.magic))
                {
                    Command cmd = CommandList.fire;

                    switch(player.bindMgk)
                    {
                        case Character.Element.Ice:
                            cmd = CommandList.ice;
                            break;
                        case Character.Element.Lightning:
                            cmd = CommandList.lightning;
                            break;
                        case Character.Element.Earth:
                            cmd = CommandList.earth;
                            break;
                    }

                    player.Magic(enemy, cmd);
                }
                break;

            default:
                int commandValue = Random.Range(1, 100);
                Enemy activeEnemy = characters[turnIndex] as Enemy;

                if(commandValue < 50)
                {
                    activeEnemy.Attack(player, CommandList.wave);
                }
                else if(commandValue < 90)
                {
                    activeEnemy.Attack(player, CommandList.bigWave);
                }
                else
                {
                    activeEnemy.Attack(player, CommandList.tsunami);
                }
                break;
        }
    } // end Update()

    public void ChangeGameState(GameState state)
    {
        switch(state)
        {
            case GameState.GameInit:
                gameState = GameState.GameInit;
                break;

            case GameState.GameStart:
                gameState = GameState.GameStart;
                break;

            case GameState.GameResume:
                gameState = GameState.GameResume;
                break;

            case GameState.GamePause:
                gameState = GameState.GamePause;
                Pause();
                break;

            case GameState.GameOver:
                gameState = GameState.GameOver;
                GameOver();
                break;
        } // end switch
    } // end ChangeGameState()

    void Pause()
    {
        if(Time.timeScale > 0.0f)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    } // end Pause()

    public void AdvanceTurn()
    {
        TurnIndex++;
    } // end AdvanceTurn()

    void GameOver()
    {
        if(player.HP > 0)
            uim.ShowResults(true);
        else
            uim.ShowResults();
    }
} // end GameManager()
