using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class scrLocation : MonoBehaviour
{
    public bool unlocked = false;
    public Renderer renderer;
    public TextMeshProUGUI text;
    public string locationText;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (unlocked)
        {
           // renderer.material.color = Color.white;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Player") && unlocked) 
        {
            Debug.Log("Test");
            renderer.material.color = Color.white;
            text.text = locationText;
        }
        else if (collision.transform.tag.Equals("Player") && !unlocked)
        {
            text.text = "This location is locked";
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
