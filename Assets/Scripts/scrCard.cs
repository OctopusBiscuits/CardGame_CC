using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCard : MonoBehaviour
{
    public string cardType;
    GameObject joshcube;
    JoshCube josh;
    GameObject player;
    scrPlayerScript playerScript;
    [SerializeField] TickMaster tick;
    GameObject tickmaster;
    srGameEnd gameEnd;
    GameObject gameEnder;
    //public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        
        joshcube = GameObject.FindWithTag("Josh");
        josh = joshcube.GetComponent<JoshCube>();
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<scrPlayerScript>();
        tickmaster = GameObject.FindWithTag("Tick");
        tick = tickmaster.GetComponent<TickMaster>();
        gameEnder = GameObject.FindWithTag("end");
        gameEnd = gameEnder.GetComponent<srGameEnd>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnd.gameOver)
        {
            Debug.Log("Destroying cards");
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Card");
            foreach (GameObject enemy in enemies)
            {
                GameObject.Destroy(enemy);
            }

        }
    }

    public void UseCard()
    {
        Debug.Log("This is a test");
        if (cardType == "Precision" && playerScript.energy > 0 && GameObject.FindGameObjectsWithTag("Enemy").Length < 2)
        {
            josh.health -= 5;
            playerScript.energy--;
            Destroy(gameObject);
            
        }
        else if (cardType == "Precision" && playerScript.energy > 0)
        {
            //Select enemy
            //Then deal damage to that enemy
        }

        else if (cardType == "Block" && playerScript.energy > 0)
        {
            playerScript.block += 5;
            playerScript.energy--;
            Destroy(gameObject);
        }
        else if (cardType == "Rest")
        {
            playerScript.energy += 1;
            Destroy(gameObject);
        }
        else if (cardType == "End")
        {
            tick.PlayerTurn = false;
            tick.tick = true;
            tick.first = true;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Card");
            foreach (GameObject enemy in enemies)
                GameObject.Destroy(enemy);
            Destroy(gameObject);
        }
        
    }
}
