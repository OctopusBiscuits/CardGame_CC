using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
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
    private Renderer renderer;
    GameObject selection;
    scrSelect select;
    scrInstructionText text;

    public bool cardPlayed = false; //Used for colour stuff.

    private Vector3 originalSize;

    
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
        renderer = GetComponent<Renderer>();

        selection = GameObject.FindWithTag("Selector");
        select = selection.GetComponent<scrSelect>();

        
        
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<scrPlayerScript>();
        tickmaster = GameObject.FindWithTag("Tick");
        tick = tickmaster.GetComponent<TickMaster>();
        text = tickmaster.GetComponent<scrInstructionText>();
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
        text.cardsDrawn();
        originalSize = transform.localScale;

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
        if (cardType == "Precision" && playerScript.energy > 0 && GameObject.FindGameObjectsWithTag("Enemy").Length < 2) //Only one enemy in the scene
        {
            
            GameObject enemy1 = realEnemyList[0];
            enemy1.GetComponent<scrCameraShakeOnAttack>().shake();
            enemy1.GetComponent<scrEnemy>().TakeDamage(5);
            playerScript.energy--;
            discardCard(true);
            //cameraShake.shake();

        }

        else if (cardType == "Precision" && playerScript.energy > 0)
        {
            //Select enemy
            text.precUsed();
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
            discardCard(true);
        }

        // Allows the character to practice their breathing exercises, restoring one energy to their bar
        else if (cardType == "Rest")
        {
            playerScript.energy += 1;
            discardCard(true);
        }

        // Make a wide attack that strikes all enemies in one go!
        else if (cardType == "Sweep" && playerScript.energy > 0)
        {
            GameObject[] updatedEnemyList = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in updatedEnemyList)
            {
                enemy.GetComponent<scrEnemy>().TakeDamage(3);
                enemy.GetComponent<scrCameraShakeOnAttack>().shake();
            }
            playerScript.energy--;
            discardCard(true);
        }

        else if (cardType == "Dodge" && playerScript.energy > 1)
        {
            playerScript.dodge = true;
            playerScript.energy--;
            discardCard(true);
        }
        else if (cardType == "End")
        {
            text.turnOver();
            tick.PlayerTurn = false;
            tick.tick = true;
            tick.first = true;
            GameObject[] cursecards = GameObject.FindGameObjectsWithTag("CurseCard");
            foreach (GameObject card in cursecards)
            {
                GameObject.Destroy(card);
            }
                
            GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
            foreach (GameObject card in cards)
            {
                card.GetComponent<scrCard>().discardCard(false);
            }
                
            
            Destroy(gameObject);
        }
        
    }

    public void discardCard(bool used)
    {
        cardPlayed = true;
        if (used)
        {
            renderer.material.color = Color.green;
        }
        else
        {
            renderer.material.color = Color.red;
        }
        StartCoroutine(cardScaling());
    }

    IEnumerator cardScaling()
    {
        Vector3 scaleUp = originalSize * 1.2f;
        Vector3 scaleDown = originalSize * 0.05f;
        float duration = 0.3f;
        float timeTaken = 0f;
        while (timeTaken < duration)
        {
            transform.localScale = Vector3.Lerp(originalSize, scaleUp, timeTaken / duration);
            timeTaken += Time.deltaTime;
            yield return null;
        }
        timeTaken = 0f;
        while (timeTaken < duration)
        {
            transform.localScale = Vector3.Lerp(scaleUp, scaleDown, timeTaken / duration);
            timeTaken += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);

    }
}
