using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class scrDisplay : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI blockText;
    public TextMeshProUGUI energyText;
    public TextMeshProUGUI test1;
    public TextMeshProUGUI meds;
    //public TextMeshProUGUI test2;
    [SerializeField] scrPlayerScript pScript;
    [SerializeField] TickMaster tick;
    public int holder;
    int holder2;
    int holder3;
    public srGameEnd gameEnd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameEnd.gameOver)
        {
            holder = pScript.playerHealth;
            holder2 = pScript.block;
            holder3 = pScript.energy;
            //int holder4 = tick.playerTick;
            //int holder5 = tick.enemyTick;
            healthText.text = " ";
            blockText.text = "Block: " + holder2;
            energyText.text = "Energy: " + holder3;
            //test1.text = "Player tick: " + holder4;
            //test2.text = "Enemy tick: " + holder5;

            /*
            if (tick.PlayerTurn)
            {
                test1.color = Color.green;
            }
            else
            {
                test1.color = Color.white;
            }
            
            if (tick.enemyTurn)
            {
                test2.color = Color.green;
            }
            else
            {
                test2.color = Color.white;
            }
            */
            if (pScript.medicated > 0)
            {
                meds.text = "Medicated";
            }
            else
            {
                meds.text = "Not medicated";
            }
        }
        else
        {
            healthText.text = " ";
            blockText.text = " ";
            energyText.text = " ";
            //test1.text = " ";
            //test2.text = " ";
        }
        
    }
}
