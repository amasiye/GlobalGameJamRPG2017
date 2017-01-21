using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Character player;
    public Character enemy;

    public float playerHP = 1000f;
    public float enemyHP = 10000f;

    public static Queue<GameObject> turnQueue;

    void Awake()
    {
        if(!player)
            player = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Character>();

        if(!enemy)
            enemy = GameObject.FindGameObjectWithTag(Tags.enemy).GetComponent<Character>();

        player.hp = playerHP;
        enemy.hp = enemyHP;
    } // end Start()

    void Update()
    {
        Debug.Log(player.hp);

    } // end Update()
}
