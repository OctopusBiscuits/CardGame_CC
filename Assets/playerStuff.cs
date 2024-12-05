using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStuff : MonoBehaviour
{
    public Camera camera;


    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.GetComponent<testScript>() != null)
                {
                    //hitInfo.collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
                    Debug.Log("The code got here");
                    hitInfo.collider.gameObject.GetComponent<scrCard>().UseCard();
                    Debug.Log("And here");
                }
            }
        }
    }
}
