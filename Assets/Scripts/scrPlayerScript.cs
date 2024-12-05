using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayerScript : MonoBehaviour
{

    public static int playerHealth = 50;
    public int tickCount = 4;
    public int howCloseToTurn = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        howCloseToTurn += tickCount;
    }


}
