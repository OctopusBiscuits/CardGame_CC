using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class scrCardDamage : MonoBehaviour
{

    public scrPlayerScript player;
    public GameObject playerScript;
    public TextMeshPro text;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindWithTag("Player");
        player = playerScript.GetComponent<scrPlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = (damage + player.damageIncrease) + " damage";
    }
}
