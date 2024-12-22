using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class scrJoshIntro : MonoBehaviour
{
    public float count;
    public TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //count += Time.deltaTime;
        //Debug.Log(count);
        if (count < 1)
        {
            textMeshPro.text = "Josh has appeared...";
        }
        else if (count < 2)
        {
            textMeshPro.text = "He isn't happy to see you.";
        }
        else if (count < 3)
        {
            textMeshPro.text = "He wants to fight!";
        }
        else
        {
            SceneManager.LoadScene(2);
        }

    }

    public void addCount()
    {
        count++;
    }
}
