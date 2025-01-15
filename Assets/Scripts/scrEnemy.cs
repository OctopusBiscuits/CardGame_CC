using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
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
    bool amIAttacking = false;
    public int chanceToAttack = 70;

    public ParticleSystem deathParticles;
    Vector3 originalSize;
    scrHealthBar myHealthBar;
    public int maxHealth;
    //GameObject camera;
    //scrCameraShakeOnAttack cameraShake;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<scrPlayerScript>();
        tickmaster = GameObject.FindWithTag("Tick");
        tick = tickmaster.GetComponent<TickMaster>();
        //camera = GameObject.FindWithTag("MainCamera");
        //cameraShake = camera.GetComponent < scrCameraShakeOnAttack>(); 
        deathParticles.Stop();
        originalSize = transform.localScale;
        myHealthBar = GetComponent<scrHealthBar>();
        maxHealth = health;
        myHealthBar.UpdateHealthBar(maxHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //As Josh gets stronger, the rotation speed increases
        if (enemyName == "Josh")
        {
            transform.Rotate(0, 0.04f * damageGiven, 0);
        }
        //tickText.text = "Tick: " + currentTick;

        if (health <= health / 2)
        {
            tickCount = 5;
        }

        if (health <= 0)
        {
            deathParticles.Play();
            text.text = "NOOOOO";
            damageText.text = " ";
            OnDeath();
        }
        
        else if (!myGo)
        {
            text.text = enemyName;
            damageText.text = "Damage Value: " + damageGiven;
        }
        else
        {
            text.text = "I think I will....";
            
        }

    }

    public void OnDeath()
    {
        

        StartCoroutine(EnemyDeath());
    }

    IEnumerator EnemyDeath()
    {

        Vector3 scaleUp = originalSize * 1.2f;
        Vector3 scaleDown = originalSize * 0.05f;
        float duration = 0.5f;
        float timeTaken = 0f;
        while (timeTaken < duration)
        {
            transform.localScale = Vector3.Lerp(originalSize, scaleUp, timeTaken / duration);
            timeTaken += Time.deltaTime;
            yield return null;
        }
        timeTaken = 0f;
        duration = 0.7f;
        while (timeTaken < duration)
        {
            transform.localScale = Vector3.Lerp(scaleUp, scaleDown, timeTaken / duration);
            timeTaken += Time.deltaTime;
            yield return null;
        }
        
        //yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {

        health -= damage;
        myHealthBar.UpdateHealthBar(maxHealth, health);
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

        //float go = Random.Range(0.0f, 2.0f);

        int Enemychoice = Random.Range(0, 100); //Random rolled
        Debug.Log("Joshcube rolled a " +Enemychoice);

        // If Enemychoice is above [Set integer] the enemy will announce that it will strike you down before dealing [Set integer] to player
        if (Enemychoice > 100 - chanceToAttack)
        {
            damageText.text = "ATTACK";
            amIAttacking = true;
            //cameraShake.shake();
        }
        else
        {
            damageText.text = "Increase my power";
            StartCoroutine(cardScaling());
        }
        

        if (Enemychoice > 100 - chanceToAttack)
        {
            playerScript.recieveDamage(damageGiven); //Reduce players health
            amIAttacking=false;
        }
        else
        {
            damageGiven += 2;
        }
        yield return new WaitForSeconds(2); //Time for player to read the enemy's text
        tick.tick = false; //Reset tick 
        tick.enemyTurn = false;
        myGo = false;
    }

    public void selectEnemy (int i)
    {

        Debug.Log("Button pressed");
    }

    IEnumerator cardScaling()
    {
        Vector3 scaleUp = originalSize * 1.9f;
        Vector3 scaleDown = originalSize;
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
        

    }
}
