using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class scrIntro : MonoBehaviour
{

    //This code is for the intro of the game - after pressing begin in the menu.
    public float count;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //count += Time.deltaTime;
        if (count < 1)
        {
            text.text = "Welcome, new sorcerer";
        }
        else if (count < 2)
        {
            text.text = "I'm sure you will do well here";
            
        }
        else if (count < 3) 
        {
            text.text = "Oh, you don't have any cards?";
        }
        else if (count < 4)
        {
            text.text = "Ohhhh, you have ADHD and you struggle to be organised";
        }
        else if (count < 5)
        {
            text.text = "Luckily, you can take these cards we have";
        }
        else if (count < 6)
        {
            text.text = "There is a lot of evil in this place. It needs to be defeated.";
        }
        else if (count < 7)
        {
            text.text = "I will send you to the map. There you can take on your first battle, against Josh";
        }
        else if (count < 8)
        {
            text.text = "By the way, your ADHD might cause some... issues during your battles";
        }
        else if (count < 9)
        {
            text.text = "Try not to let these hinder you. I am sure you will do great";
        }
        else
        {
            SceneManager.LoadScene(1);
        }

    }

    public void increaseCount()
    {
        count++;
    }
}