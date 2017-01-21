using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Character player;
    public Character enemy;

    public float characterHP = 1000f;
    public float enemyHP = 10000f;

    public Queue<GameObject> turnQueue;

    void Start()
    {
        if(!player)
            player = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Character>();

        if(!enemy)
            enemy = GameObject.FindGameObjectWithTag(Tags.enemy).GetComponent<Character>();


    } // end Start()

    void Update()
    {
    } // end Update()


}
