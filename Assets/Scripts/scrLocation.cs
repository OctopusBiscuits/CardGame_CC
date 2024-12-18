using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class scrLocation : MonoBehaviour
{
    //Im sorry guys if any of you check this, this code might be disgusting
    //To make sure location locks can be passed between scenes, an array stores bool values for each location being locked/unlocked
    
    
    public bool unlocked = false;
    public Renderer renderer;
    public TextMeshProUGUI text;
    public string locationText;
    public int locationNumber;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();

        //This checks if the level number is in the list of unlocked levels. If it is, the level is unlocked.
        if (scrLocationManager.Instance.unlockedLevels.Contains(locationNumber))
        {
            unlocked = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (unlocked)
        {
           // renderer.material.color = Color.white;
        }
    }
    //These next two methods are called when player enters/leaves a location.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Player") && unlocked) 
        {
            Debug.Log("Test");
            renderer.material.color = Color.white;
            text.text = locationText;
            scrPlayerMove playerScript = collision.gameObject.GetComponent<scrPlayerMove>();
            playerScript.currentLocation = locationNumber;
        }
        else if (collision.transform.tag.Equals("Player") && !unlocked)
        {
            text.text = "This location is locked";
            scrPlayerMove playerScript = collision.gameObject.GetComponent<scrPlayerMove>();
            playerScript.currentLocation = locationNumber;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            Debug.Log("Test");
            renderer.material.color = Color.red;
            text.text = " ";
        }


    }

}
