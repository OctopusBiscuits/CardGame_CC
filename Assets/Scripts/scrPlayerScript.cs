using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class scrPlayerScript : MonoBehaviour
{

    public int playerHealth = 50;
    public int block = 0;
    public int tickCount = 4;
    public int howCloseToTurn = 0;
    public int energy = 3;
    public int damageIncrease = 0;
    public Camera camera;
    public bool dodge = false;
    public srGameEnd gameEnd;
    private Rigidbody rigidbody;
    public bool beingAttacked = false;
    private scrHealthBar healthBar;
    float maxHealth;
    public int medicated = 0;
    public TextMeshProUGUI dodgeText;
    private RectTransform dodgePos;
    public Color dodgeScreenCol;
    public Image dodgeBackground;
    // Start is called before the first frame update
    void Start()
    {
        medicated = 0;
        healthBar = GetComponent<scrHealthBar>();
        maxHealth = playerHealth;
        healthBar.UpdateHealthBar(maxHealth, maxHealth);
        dodgePos = dodgeText.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //howCloseToTurn += tickCount;
        dodgeBackground.color = dodgeScreenCol;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.GetComponent<testScript>() != null)
                {
                    //hitInfo.collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
                    Debug.Log("The code got here");
                    hitInfo.collider.gameObject.GetComponent<scrCard>().UseCard();
                    Debug.Log("And here");
                }
            }
        }
        if (energy > 3)
        {
            energy = 3;
        }
    }

    public void recieveDamage(int damage)
    {
        //If there is > 0 block, that is recieved first
        //Then health
        if (dodge)
        {
            //dodge = false;
            dodgeScreen();
            return; //If player has used a dodge card, this blocks ANY damage from occuring this turn.
        }

        beingAttacked = true;
        StartCoroutine(FlashRed());
        block = block - damage;
        if (block < 0)
        {
            playerHealth += block;
            block = 0;
        }
        if (playerHealth <= 0)
        {
            gameEnd.battleOver(false);
        }
        healthBar.UpdateHealthBar(maxHealth, playerHealth);
       

    }
    IEnumerator FlashRed()
    {
        yield return new WaitForSeconds(2);
        beingAttacked = false;
    }

    public void dodgeScreen()
    {
        dodgeScreenCol.a = 0.886f;
        
        StartCoroutine(dodging());
       
    }
    IEnumerator dodging()
    {
        float duration = 1.0f;
        dodgePos.anchoredPosition = new Vector2 (-50.0f, 0.0f);
        Vector2 hold = new Vector2(1.0f, 0.0f);
        Vector2 finalPos = new Vector2(50.0f, 0.0f);
        yield return StartCoroutine(moveText(dodgePos, Vector2.zero, duration));
        yield return StartCoroutine(moveText(dodgePos, hold, duration));
        yield return StartCoroutine(moveText(dodgePos, finalPos, duration));
        dodgeScreenCol.a = 0;
        
    }
    IEnumerator moveText(RectTransform dodgePos, Vector2 newPos, float duration)
    {
        Vector2 startingPos = dodgePos.anchoredPosition;
        float timeTaken = 0.0f;
        while (timeTaken < duration)
        {
            dodgePos.anchoredPosition = Vector2.Lerp(startingPos, newPos, timeTaken / duration);
            timeTaken += Time.deltaTime; 
            yield return null;
        }

        dodgePos.anchoredPosition = newPos;
    }

}
