using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scrCard : MonoBehaviour
{
    public string cardType;
    GameObject joshcube;
    scrEnemy josh;
    GameObject player;
    scrPlayerScript playerScript;
    [SerializeField] TickMaster tick;
    GameObject tickmaster;
    srGameEnd gameEnd;
    GameObject gameEnder;
    GameObject cardToDelete; //Used for precision attack selection
    public List<GameObject> realEnemyList = new List<GameObject>();
    
    GameObject selection;
    scrSelect select;
    //public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemyList)
        {
            realEnemyList.Add(enemy);
        }
        /*
        if (SceneManager.GetActiveScene().name == "CardTest")
        {
            joshcube = GameObject.FindWithTag("Josh");
            josh = joshcube.GetComponent<scrEnemy>();
        }
        */
        
        selection = GameObject.FindWithTag("Selector");
        select = selection.GetComponent<scrSelect>();
        
        
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
        /*
        if (gameEnd.gameOver)
        {
            Debug.Log("Destroying cards");
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Card");
            foreach (GameObject enemy in enemies)
            {
                GameObject.Destroy(enemy);
            }

        }
        */
        
    }

    public void UseCard()
    {
        if (select.selectMode == true)
        {
            return; //This ensures that if the player has clicked a precision card and is choosing an enemy to attack, they cannot use any other cards
        }
        Debug.Log("This is a test");
        if (cardType == "Precision" && playerScript.energy > 0 && GameObject.FindGameObjectsWithTag("Enemy").Length < 2)
        {

            GameObject enemy1 = realEnemyList[0];
            enemy1.GetComponent<scrEnemy>().health -= 5;
            playerScript.energy--;
            Destroy(gameObject);

        }
        else if (cardType == "Precision" && playerScript.energy > 0)
        {
            //Select enemy
            playerScript.energy--;
            Debug.Log("Here");
            select.selectMode = true;
            cardToDelete = this.gameObject;

            gameObject.tag = "Delete";
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
        else if (cardType == "Sweep" && playerScript.energy > 0)
        {
            GameObject[] updatedEnemyList = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in updatedEnemyList)
            {
                enemy.GetComponent<scrEnemy>().health -= 2;
            }
            playerScript.energy--;
            Destroy(gameObject);
        }
        else if (cardType == "Dodge" && playerScript.energy > 0)
        {
            playerScript.dodge = true;
            playerScript.energy--;
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
