using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayerScript : MonoBehaviour
{

    public int playerHealth = 50;
    public int block = 0;
    public int tickCount = 4;
    public int howCloseToTurn = 0;
    public int energy = 3;
    public Camera camera;


    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //howCloseToTurn += tickCount;

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
