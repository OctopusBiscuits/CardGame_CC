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
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 1)
        {
            battleOver(true);
        }
        
    }

    

    public void battleOver(bool playerWin)
    {
        /*
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Josh"))
        {
            Destroy(enemy.gameObject);
        }
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy.gameObject);
        }
        */
        foreach (GameObject card in GameObject.FindGameObjectsWithTag("Card"))
        {
            Destroy(card.gameObject);
        }
        GameObject[] cursecards = GameObject.FindGameObjectsWithTag("CurseCard");
        foreach (GameObject card in cursecards)
        {
            GameObject.Destroy(card);
        }
            
        text.transform.position = new Vector3(0, 0, 0);
        gameOver = true;
        if (playerWin)
        {
            text.text = "Battle over. You won!!!!!";
            scrLocationManager.Instance.unlockedLevels.Add(2);
        }
        else
        {
            text.text = "Battle over. You were defeated";
        }
        StartCoroutine(pause());
    }
    IEnumerator pause()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("We're here");
        SceneManager.LoadScene(1);

    }
}
