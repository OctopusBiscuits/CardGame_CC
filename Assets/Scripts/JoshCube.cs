using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class JoshCube : MonoBehaviour
{
    public static int tickCount = 4;
    public string enemyName;
    public TextMeshProUGUI text;
    public TextMeshProUGUI damageText;
    public int health = 10;
    int count = 0;
    public int damageGiven = 6;
    public GameObject player;
    scrPlayerScript playerScript;
    GameObject tickmaster;
    TickMaster tick;
    public srGameEnd gameEnd;
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
        transform.Rotate(0, 0.02f * damageGiven, 0);

        
        if (!tick.enemyTurn)
        {
            text.text = enemyName + ", Health : " + health;
            damageText.text = "Damage Value: " + damageGiven;
        }
        else
        {
            text.text = "I think I will....";
            //damageText.text = " ";
        }
        
        if (health <= 0)
        {
            gameEnd.battleOver(true);
            Destroy(gameObject);
        }
        
    }

    private void FixedUpdate()
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
        damageText.text = " ";
        Debug.Log("In the enemyGo");
        yield return new WaitForSeconds(2);
        Debug.Log("Pause over");
        float go = Random.Range(0.0f, 2.0f);
        Debug.Log("Joshcube rolled a " + go);
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
    }
}

