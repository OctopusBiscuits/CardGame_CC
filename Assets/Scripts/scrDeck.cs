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
    public GameObject end;
    public GameObject sweepCard;
    float test = 2;
    bool multipleEnemies;
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
        //Check how many enemies are in the level to determine if Sweep card is needed
        if(GameObject.FindGameObjectsWithTag("Enemy").Length > 1)
        {
            multipleEnemies = true;
        }
        else
        {
            multipleEnemies = false;
        }

        DeckShuffle();
        printDeck();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (shuffledDeck.Count < 5)
        {
            DeckShuffle();
        }
    }

    void DeckShuffle()
    {
        theDeck.Clear();

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
        if (multipleEnemies)
        {
            theDeck.Add(7);
            theDeck.Add(7);
            theDeck.Add(7);
        }
        //Randomise the order using Fisher-Yates

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

    public void drawCards()
    {
        curseinDeck = false;
        int numCardsDrawn = 0;
        Vector3 endturnpos = new Vector3(10f, -3.0f, 0.0f);
        while (numCardsDrawn < 5)
        {
            Vector3 newPos = new Vector3(7.0f - (3.5f * numCardsDrawn), -3f, 0.0f);
            
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
            else if (shuffledDeck.Peek() == 5)
            {
                GameObject card = Instantiate(timeCard, newPos, Quaternion.identity);
                curseinDeck = true;
                shuffledDeck.Dequeue();
                numCardsDrawn++;
            }
            else if (shuffledDeck.Peek() == 6 )
            {
                GameObject card = Instantiate(misplaceCard, newPos, Quaternion.identity);
                curseinDeck = true;
                shuffledDeck.Dequeue();
                numCardsDrawn++;
            }
            else if (shuffledDeck.Peek() == 7)
            {
                GameObject card = Instantiate(sweepCard, newPos, Quaternion.identity);
                shuffledDeck.Dequeue();
                numCardsDrawn++;
            }
            
        }

        GameObject endTurn = Instantiate(end, endturnpos, Quaternion.identity);
        
        
    }
}
