using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class scrDisplay : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI blockText;
    public TextMeshProUGUI energyText;
    public TextMeshProUGUI test1;
    public TextMeshProUGUI test2;
    [SerializeField] scrPlayerScript pScript;
    [SerializeField] TickMaster tick;
    public int holder;
    int holder2;
    int holder3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        holder = pScript.playerHealth;
        holder2 = pScript.block;
        holder3 = pScript.energy;
        int holder4 = tick.playerTick;
        int holder5 = tick.enemyTick;
        healthText.text = "Health: " + holder;
        blockText.text = "Block: " + holder2;
        energyText.text = "Energy: " + holder3;
        test1.text = "Player tick: " + holder4;
        test2.text = "Enemy tick: " + holder5;
    }
}
