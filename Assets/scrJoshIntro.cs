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
            textMeshPro.text = "As you were trying to pogress forward, an odd cube showed to block your way forward..";
        }
        else if (count < 2)
        {
            textMeshPro.text = "All your attempts to walk around them seems to have left them agitated..  .";
        }
        else if (count < 3)
        {
            textMeshPro.text = "It seems like the only way past them now is fighting your way through!!";
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
