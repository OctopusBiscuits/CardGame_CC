using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ticktest : MonoBehaviour
{
    public TextMeshPro text;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "p tick: " + player.GetComponent<TickMaster>().playerTick;
    }
}
