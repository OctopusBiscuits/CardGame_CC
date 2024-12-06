using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class scrDisplay : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI blockText;
    public TextMeshProUGUI energyText;
    [SerializeField] scrPlayerScript pScript;
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
        healthText.text = "Health: " + holder;
        blockText.text = "Block: " + holder2;
        energyText.text = "Energy: " + holder3;
    }
}
