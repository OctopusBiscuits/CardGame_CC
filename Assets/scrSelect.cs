using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrSelect : MonoBehaviour
{
    public bool selectMode = false;
    public bool tellCardToDelete = false;
    public string selectedEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tellCardToDelete)
        {

        }
    }

    public void Select(GameObject thisEnemy)
    {
        Debug.Log("Test");
        if (selectMode)
        {
            
            thisEnemy.GetComponent<scrEnemy>().health -= 5;
            tellCardToDelete = true;
        }
        else
        {
            Debug.Log("Not in select mode!");
        }
        selectMode = false;
    }
}
