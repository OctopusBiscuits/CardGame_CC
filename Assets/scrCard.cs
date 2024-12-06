using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCard : MonoBehaviour
{
    public string cardType;
    GameObject joshcube;
    JoshCube josh;
    GameObject player;
    scrPlayerScript playerScript;
    //public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        joshcube = GameObject.FindWithTag("Josh");
        josh = joshcube.GetComponent<JoshCube>();
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<scrPlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseCard()
    {
        Debug.Log("This is a test");
        if (cardType == "Precision" && playerScript.energy > 0)
        {
            josh.health -= 10;
            playerScript.energy--;
            Destroy(gameObject);
            
        }

        else if (cardType == "Block" && playerScript.energy > 0)
        {
            playerScript.block += 5;
            playerScript.energy--;
            Destroy(gameObject);
        }
        else if (cardType == "Rest")
        {
            playerScript.energy += 1;
            Destroy(gameObject);
        }
    }
}
