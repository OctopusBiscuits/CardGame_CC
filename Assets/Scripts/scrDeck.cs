using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrDeck : MonoBehaviour
{
    public List<int> theDeck = new List<int>();
    public int deckSize = 13;
    public bool curseinDeck = false;
    public Queue<int> shuffledDeck = new Queue<int>();
    public GameObject precCard;
    public GameObject blockCard;
    public GameObject restCard;
    public GameObject timeCard;
    public GameObject dodgeCard;
    public GameObject misplaceCard;
    float test = 2;
    /*
    public int precCount = 4;
    public int bloCount = 4;
    public int dodgeCount = 1;
    public int restCount = 2;
    public int timeCount = 1;
    public int misplaceCount = 1;
    */
    // Start is called before the first frame update
    /*
     * precision = 1
     * block = 2
     * rest = 3
     * 
     * 
     */
    void Start()
    {
        DeckShuffle();
        printDeck();
    }

    // Update is called once per frame
    void Update()
    {
        test -= Time.deltaTime;
        if (test < 0)
        {
            drawCards();
            test = 50000;
        }
    }

    void DeckShuffle()
    {
        

        theDeck.Add(1);
        theDeck.Add(1);
        theDeck.Add(1);
        theDeck.Add(1);
        theDeck.Add(2);
        theDeck.Add(2);
        theDeck.Add(2);
        theDeck.Add(2);
        theDeck.Add(3);
        theDeck.Add(4);
        theDeck.Add(4);
        theDeck.Add(5);
        theDeck.Add(6);

        //Randomise the order

        for (int i = theDeck.Count - 1; i >= 0; i--)
        {
            int b = Random.Range(0, theDeck.Count - 1);
            int temp = theDeck[i];
            theDeck[i] = theDeck[b];
            theDeck[b] = temp;
        }
        foreach (int i in theDeck)
        {
            shuffledDeck.Enqueue(i);
        }
    }

    void printDeck()
    {
        foreach (int i in shuffledDeck)
        {
            Debug.Log(i);
        }

    }

    void drawCards()
    {
        curseinDeck = false;
        int numCardsDrawn = 0;
        while (numCardsDrawn < 5)
        {
            Vector3 newPos = new Vector3(8.0f - (3.5f * numCardsDrawn), -3.0f, 0.0f);
            if (shuffledDeck.Peek() == 1)
            {
                GameObject card = Instantiate(precCard, newPos, Quaternion.identity);
                shuffledDeck.Dequeue();
                numCardsDrawn++;
            }
            else if (shuffledDeck.Peek() == 2)
            {
                GameObject card = Instantiate(blockCard, newPos, Quaternion.identity);
                shuffledDeck.Dequeue();
                numCardsDrawn++;
            }
            else if (shuffledDeck.Peek() == 3)
            {
                GameObject card = Instantiate(dodgeCard, newPos, Quaternion.identity);
                shuffledDeck.Dequeue();
                numCardsDrawn++;
            }
            else if (shuffledDeck.Peek() == 4)
            {
                GameObject card = Instantiate(restCard, newPos, Quaternion.identity);
                shuffledDeck.Dequeue();
                numCardsDrawn++;
            }
            else if (shuffledDeck.Peek() == 5 && curseinDeck == false)
            {
                GameObject card = Instantiate(timeCard, newPos, Quaternion.identity);
                curseinDeck = true;
                shuffledDeck.Dequeue();
                numCardsDrawn++;
            }
            else if (shuffledDeck.Peek() == 6 && curseinDeck == false)
            {
                GameObject card = Instantiate(misplaceCard, newPos, Quaternion.identity);
                curseinDeck = true;
                shuffledDeck.Dequeue();
                numCardsDrawn++;
            }
            
        }
        
        
    }
}
