using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrSelect : MonoBehaviour
{
    public bool selectMode = false;
    GameObject delete;
    public string selectedEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    public void Select(GameObject thisEnemy)
    {
        Debug.Log("Test");
        if (selectMode)
        {
            
            thisEnemy.GetComponent<scrEnemy>().health -= 5;
            delete = GameObject.FindWithTag("Delete");
            Destroy(delete);
        }
        else
        {
            Debug.Log("Not in select mode!");
        }
        selectMode = false;
    }
}
