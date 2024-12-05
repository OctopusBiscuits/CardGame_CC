using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickMaster : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public static bool tick = true;
    public int playerTick = 0; //current tick count
    public int enemyTick = 0;
    public int playerIncrease = 4;
    public int enemyIncrease = 4;
    // Start is called before the first frame update
    void Start()
    {
        //how much to increase by
    }

    // Update is called once per frame
    void Update()
    {

        while (tick)
        {
            playerTick += playerIncrease;
            enemyTick += enemyIncrease;
            if (playerTick >= 10)
            {
                tick = false;
                Debug.Log("Player can now go");
                break;
            }
            if (enemyTick >= 10)
            {
                tick = false;
                Debug.Log("Enemy can now go");
                break;
            }
        }


        //Tick Loop
        //Player goes up 1
        //Enemy goes up 1
        //Check if one equals 10
        //Then that one goes
        //If both equal 10 player goes first

    }
}
