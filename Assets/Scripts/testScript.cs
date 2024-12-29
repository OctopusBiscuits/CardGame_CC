using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    private Renderer renderer;
    private Rigidbody rigidbody;
    public scrCard cardScript;
    public Camera camera;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        cardScript = GetComponent<scrCard>();
    }

    private void OnMouseEnter()
    {
        if (!cardScript.cardPlayed)
        {
            renderer.material.color = Color.red;
        }
        
    }

    private void OnMouseExit()
    {
        if (cardScript.cardPlayed == false)
        {
            renderer.material.color = Color.white;
        }
        
    }

    
}
