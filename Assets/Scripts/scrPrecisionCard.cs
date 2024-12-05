using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPrecisionCard : MonoBehaviour
{
    public JoshCube josh;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        josh = cube.GetComponent<JoshCube>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Renderer>().material.color == Color.green)
        {
            Debug.Log("Balls");
            UseCard();
        }
    }

    

    public void UseCard()
    {
        josh.health -= 5;
        Destroy(gameObject);
    }
}
