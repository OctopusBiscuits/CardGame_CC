using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class scrSweepLoad : MonoBehaviour
{
    float timeCount = 6;
    int count = 0;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCount -= Time.deltaTime;
        if (timeCount <= 0)
        {
            SceneManager.LoadScene(5);
        }
        if (count == 0)
        {
            text.text = "After defeating Josh, you anxiously walk into the next room";
        }
        else if (count == 1)
        {
            text.text = "Unluckily for you, there are three creatures here. They are not happy";
        }
        else if (count == 2)
        {
            text.text = "Luckily, you now have your sweep card. Get ready to use it!";
        }
        else if (count == 3)
        {
            SceneManager.LoadScene(5);
        }
    }

    public void OnClick()
    {
        count++;
    }
}
