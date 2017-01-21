﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    void Awake()
    {
        if(!player)
            player = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Player>();

        if(!enemy)
            enemy = GameObject.FindGameObjectWithTag(Tags.enemy).GetComponent<Enemy>();

        player.HP = playerHP;
        enemy.HP = enemyHP;
    } // end Start()

    void Update()
    {
        // Player Commands
        // Attack
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
                    Debug.Log("Magic");
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

    public void AdvanceTurn()
    {
        TurnIndex++;
    } // end AdvanceTurn()
} // end GameManager()
