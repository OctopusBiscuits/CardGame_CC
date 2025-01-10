using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class scrSpellBook : MonoBehaviour
{
    public int count = 0;
    public TextMeshProUGUI text;
    public GameObject block;
    public GameObject Prec;
    public GameObject Sweep;
    public GameObject strength;
    public GameObject rest;
    public GameObject time;
    public GameObject misplace;
    public GameObject meds;
    public GameObject dodge;
    Vector3 cardLocation = new Vector3(-3.0f, 0.0f, 0.0f);
    GameObject card1 = null;
    GameObject card2 = null;
    GameObject card3 = null;
    GameObject card4 = null;
    GameObject card5 = null;
    GameObject card6 = null;
    GameObject card7 = null;
    GameObject card8 = null;
    GameObject card9 = null;
    // Start is called before the first frame update
    void Start()
    {
        card1 = Instantiate(block, cardLocation, Quaternion.identity);
        text.text = "If an enemy attacks while you have block, your block will be reduced before your health. " +
            "Block resets to zero at the start of your next turn.";
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void IncreaseCount()
    {
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        foreach (GameObject card in cards)
        {
            card.GetComponent<scrCard>().discardCard(false);
        }
        GameObject[] cursecards = GameObject.FindGameObjectsWithTag("CurseCard");
        foreach (GameObject card in cursecards)
        {
            GameObject.Destroy(card);
        }
        count++;
        
        if (count == 1)
        {
           
            
            text.text = "This deals 5 damage to one enemy. ";
            card2 = Instantiate(Prec, cardLocation, Quaternion.identity);
        }
        else if (count == 2)
        {
            
            text.text = "This deals 3 damage to each enemy.";
            card3 = Instantiate(Sweep, cardLocation, Quaternion.identity);
        }
        else if (count == 3)
        {
            
            text.text = "Once this card is played, the damage given by sweep and preciion cards will increase by 2. For example, on first use precision will increase from 5 to 7 damage. This resets after each fight";
            card4 = Instantiate(strength, cardLocation, Quaternion.identity);
        }
        else if (count == 4)
        {
            
            text.text = "Once this card is played, you will dodge all enemy attacks until your next turn";
            card5 = Instantiate(dodge, cardLocation, Quaternion.identity);
        }
        else if (count == 5)
        {
            
            text.text = "This card adds one energy to your character. Max energy is three. Every turn, you gain one energy automatically.";
            card6 = Instantiate(rest, cardLocation, Quaternion.identity);
        }
        else if (count == 6)
        {
            
            text.text = "Due to you having ADHD, you find it hard to keep track of time. If this card is drawn, you will have to wait longer for your next turn. This is played automatically";
            card7 = Instantiate(time, cardLocation, Quaternion.identity);
        }
        else if (count == 7)
        {
            
            text.text = "Due to you having ADHD, you also misplace items a lot. If this card is drawn, your character has managed to lose a card. This is played automatically";
            card8 = Instantiate(misplace, cardLocation, Quaternion.identity);
        }
        else if (count == 8)
        {
            
            text.text = "This is your ADHD medication. Taking this makes ADHD symptoms less likely to occur for three turns. However, this has a side effect of fatigue: rest cards are less likely to be drawn";
            card9 = Instantiate(meds, cardLocation, Quaternion.identity);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
        
    }
}
