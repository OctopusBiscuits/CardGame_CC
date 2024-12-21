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

        if (cardType == "Time")
        {
            TimeBlindness();
        }
        else if (cardType == "Misplace")
        {
            Misplace();
        }
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

    public void TimeBlindness()
    {
        tick.activeTimeBlindness = true;
        StartCoroutine(Pause());
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(5);
        //Destroy(gameObject);
    }
    public void Misplace()
    {
        GameObject[] possibleDeletion = GameObject.FindGameObjectsWithTag("Card");
        int length = possibleDeletion.Length;
        int randomDeletion = Random.Range(0, length);
        Destroy(possibleDeletion[randomDeletion]);
        StartCoroutine(Pause());
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

        // Provides block to the players healthbar. This prevents a set amount of damage dealt by the enemy attacks
        else if (cardType == "Block" && playerScript.energy > 0)
        {
            playerScript.block += 5;
            playerScript.energy--;
            Destroy(gameObject);
        }

        // Allows the character to practice their breathing exercises, restoring one energy to their bar
        else if (cardType == "Rest")
        {
            playerScript.energy += 1;
            Destroy(gameObject);
        }

        // Make a wide attack that strikes all enemies in one go!
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
            GameObject[] cursecards = GameObject.FindGameObjectsWithTag("CurseCard");
            foreach (GameObject card in cursecards)
                GameObject.Destroy(card);
            GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
            foreach (GameObject card in cards)
                GameObject.Destroy(card);
            
            Destroy(gameObject);
        }
        
    }
}
