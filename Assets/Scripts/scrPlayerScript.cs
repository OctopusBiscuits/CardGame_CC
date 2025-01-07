using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayerScript : MonoBehaviour
{

    public int playerHealth = 50;
    public int block = 0;
    public int tickCount = 4;
    public int howCloseToTurn = 0;
    public int energy = 3;
    public Camera camera;
    public bool dodge = false;
    public srGameEnd gameEnd;
    private Rigidbody rigidbody;
    public bool beingAttacked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //howCloseToTurn += tickCount;

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

       

    }
    IEnumerator FlashRed()
    {
        yield return new WaitForSeconds(2);
        beingAttacked = false;
    }

}
