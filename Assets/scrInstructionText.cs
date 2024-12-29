using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scrInstructionText : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cardsDrawn()
    {
        text.text = "(click a card to play it)";
    }

    public void precUsed()
    {
        text.text = "(select an enemy's button to attack)";
    }
    public void turnOver()
    {
        text.text = " ";
    }
}
