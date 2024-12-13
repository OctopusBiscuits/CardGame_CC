using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class srGameEnd : MonoBehaviour
{
    /*
     * This is called when player or enemy health hits zero
     * Should remove all UI stuff and the enemy
     * Show text showing game stats/state
     * 
     */
    // Start is called before the first frame update
    public bool gameOver = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enemyWin()
    {
        Debug.Log("Enemy win");
        gameOver = true;
    }

    public void playerWin()
    {
        Debug.Log("Player win");
        gameOver = true;
    }
}
