using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class scrLevelLoading : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    public GameObject player;
    scrPlayerMove playerScript;
    public int playerLocation;
    bool canClick = false;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<scrPlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        playerLocation = playerScript.currentLocation;
        if (scrLocationManager.Instance.unlockedLevels.Contains(playerLocation))
        {
            canClick = true;
            buttonText.text = "Start Level";
        }
        else
        {
            canClick = false;
            buttonText.text = "Locked";
        }
    }

    public void OnClick()
    {
        if (playerLocation == 1 && canClick)
        {
            SceneManager.LoadScene(3);
        }
        else if (playerLocation == 2 && canClick)
        {
            SceneManager.LoadScene(4);
        }
    }
}
