using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class scrEnemy : MonoBehaviour
{
    public int tickCount = 4;
    public int currentTick = 0;
    public string enemyName;
    public int health = 10;
    int count = 0;
    public int damageGiven = 6;
    public GameObject player;
    scrPlayerScript playerScript;
    GameObject tickmaster;
    TickMaster tick;
    public srGameEnd gameEnd;
    public TextMeshProUGUI text;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI tickText;
    public bool myGo;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<scrPlayerScript>();
        tickmaster = GameObject.FindWithTag("Tick");
        tick = tickmaster.GetComponent<TickMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        //As Josh gets stronger, the rotation speed increases
        if (enemyName == "josh")
        {
            transform.Rotate(0, 0.02f * damageGiven, 0);
        }
        tickText.text = "Tick: " + currentTick;

        if (health <= 0)
        {         
            Destroy(gameObject);
        }
        
        if (!myGo)
        {
            text.text = enemyName + ", Health : " + health;
            damageText.text = "Damage Value: " + damageGiven;
        }
        else
        {
            text.text = "I think I will....";
            
        }

    }

    private void FixedUpdate()
    {
        if (enemyName == "josh")
        {
            if (count < 50)
            {
                Vector3 aPos = transform.position;
                aPos.y = aPos.y + 0.01f;
                transform.position = aPos;
                count++;
            }
            else if (count < 100)
            {
                Vector3 aPos = transform.position;
                aPos.y = aPos.y - 0.01f;
                transform.position = aPos;
                count++;
            }
            else if (count == 100)
            {
                count = 0;
            }
        }
        

    }
    

    public void MyTurn()
    {
        /*
         * This should have a visual impact so the player can see the enemy is going.
         * Should also last longer than 0.01 seconds
            Imagine its like "Enemy Attack:
        Josh Uses DAMAGE!!!!!!!!"
        Coroutine is called so there can be pauses. This makes the attack last longer than 0.01 seconds
         */

        StartCoroutine(EnemyGo());


    }
    IEnumerator EnemyGo()
    {
        myGo = true;    
        damageText.text = " ";
        Debug.Log("In the enemyGo");
        yield return new WaitForSeconds(2);
        Debug.Log("Pause over");
        float go = Random.Range(0.0f, 2.0f);
        if (go > 0.4)
        {
            damageText.text = "ATTACK";
        }
        else
        {
            damageText.text = "Increase my power";
        }
        yield return new WaitForSeconds(2);

        if (go > 0.4f)
        {
            playerScript.recieveDamage(damageGiven);
        }
        else
        {
            damageGiven += 2;
        }
        tick.tick = false;
        tick.enemyTurn = false;
        myGo = false;
    }

    public void selectEnemy (int i)
    {

        Debug.Log("Button pressed");
    }
}
