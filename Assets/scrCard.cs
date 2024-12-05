using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCard : MonoBehaviour
{
    public string cardType;
    GameObject joshcube;
    JoshCube josh;
    //public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        joshcube = GameObject.FindWithTag("Josh");
        josh = joshcube.GetComponent<JoshCube>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseCard()
    {
        Debug.Log("This is a test");
        if (cardType == "Precision")
        {
            josh.health -= 10;
            Destroy(gameObject);
        }
    }
}
