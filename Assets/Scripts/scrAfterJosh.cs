using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class scrAfterJosh : MonoBehaviour
{
    public int count;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0)
        {
            text.text = "Congratulations. You defeated Josh";
        }
        if (count == 1)
        {
            text.text = "Here's a reward for you: a new card!";
        }
        if (count == 2)
        {
            text.text = "It will be useful for you in your next fight...";
        }
        if (count == 3)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void IncreaseCount()
    {
        count++;
    }
}
