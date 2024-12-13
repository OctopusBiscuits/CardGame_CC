using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class srGameEnd : MonoBehaviour
{
    /*
     * This is called when player or enemy health hits zero
     * Should remove all UI stuff and the enemy
     * Show text showing game stats/state
     * 
     */
    // Start is called before the first frame update
    public TextMeshPro text;
    public bool gameOver = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void battleOver(bool playerWin)
    {
        text.transform.position = new Vector3(0, 0, 0);
        gameOver = true;
        if (playerWin)
        {
            text.text = "Battle over. You defeated Josh!!!!!";
        }
        else
        {
            text.text = "Battle over. Josh defeated you";
        }
        StartCoroutine(pause());
    }
    IEnumerator pause()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);

    }
}
