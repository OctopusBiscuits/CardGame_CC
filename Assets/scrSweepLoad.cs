using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scrSweepLoad : MonoBehaviour
{
    float timeCount = 6;
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
    }
}
