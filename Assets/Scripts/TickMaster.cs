using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickMaster : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;

    public bool tick = false;
    public int playerTick = 0; //current tick count
    //public int enemyTick = 0;

    public int playerIncrease = 4;
    //public int enemyIncrease = 4;
    public bool PlayerTurn = false;
    float timeToTick = 1; //How long between each tick
    public GameObject deck;
    scrDeck deckScript;
    scrEnemy joshScript;
    scrPlayerScript scrPlayer;
    public bool first = true;
    public bool enemyTurn = false;
    public bool activeTimeBlindness = false;
    // Start is called before the first frame update
    void Start()
    {
        deck = GameObject.FindGameObjectWithTag("Deck");
        deckScript = deck.GetComponent<scrDeck>();
        joshScript = enemy.GetComponent<scrEnemy>();
        scrPlayer = player.GetComponent<scrPlayerScript>();
        
    }

    // Update is called once per frame
    void Update()
    {

        timeToTick -= Time.deltaTime;
        //This if statement counts down the time until the tick count should increase
        if (timeToTick < 0)
        {
            tick = true;
            timeToTick = 1;
            //Debug.Log("Ticking");
        }
        
        //This increases the player and enemies tick counts  (if it is not the enemy/player's turn to attack)
        if (tick && !PlayerTurn && !enemyTurn)
        {
            
            timeToTick = 1;
            
            if (!activeTimeBlindness) //Check player does not suffer from time blindness
            {
                playerTick += playerIncrease;
            }
            else
            {
                activeTimeBlindness = false;
            }
            
            
            if (playerTick >= 10) //Player's turn
            {
                scrPlayer.dodge = false;
                scrPlayer.block = 0;
                tick = false;
                Debug.Log("Player can now go");
                scrPlayer.energy++;
                deckScript.drawCards();
                //playerTick = 0;
                //playerTick = 0;
                PlayerTurn = true;

                playerTick -= 10;
                //first = false;
                //break;
                
            }
            
            if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0 ) //Enemies turn
            {
                foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    scrEnemy enemyScript = enemy.GetComponent<scrEnemy>();
                    enemyScript.currentTick += enemyScript.tickCount;
                    if (enemyScript.currentTick >= 10 && !PlayerTurn)
                    {
                        tick = false;
                        enemyScript.currentTick -= 10;
                        enemyScript.myGo = true;
                        enemyScript.MyTurn();
                        enemyTurn = true;
                    }

                }
            }
            if (GameObject.FindGameObjectsWithTag("Josh").Length > 0)
            {
                Debug.Log("Josh");
                foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Josh"))
                {
                    scrEnemy enemyScript = enemy.GetComponent<scrEnemy>();
                    enemyScript.currentTick += enemyScript.tickCount;
                    if (enemyScript.currentTick >= 10 && !PlayerTurn)
                    {
                        tick = false;
                        enemyScript.currentTick -= 10;
                        enemyScript.myGo = true;
                        enemyScript.MyTurn();
                        enemyTurn = true;
                    }

                }
            }
            
            
        }
        tick = false;

        //Tick Loop
        //Player goes up 1
        //Enemy goes up 1
        //Check if one equals 10
        //Then that one goes
        //If both equal 10 player goes first

    }
}
