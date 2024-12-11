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
    public int health = 10;
    int count = 0;
    public int damageGiven = 6;
    public GameObject player;
    scrPlayerScript playerScript;
    GameObject tickmaster;
    TickMaster tick;
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

        transform.Rotate(0, 0.1f, 0);

        if (health == 0)
        {
            SceneManager.LoadScene(1);
            Destroy(gameObject);

        }
        text.text = enemyName + ", Health : " + health;

        
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
        float go = Random.Range(0.0f, 2.0f);
        if (go > 0.5f)
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
