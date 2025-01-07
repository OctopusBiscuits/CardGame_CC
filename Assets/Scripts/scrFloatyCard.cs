using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrFloatyCard : MonoBehaviour
{
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        //count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (count < 50)
        {
            Vector3 aPos = transform.position;
            aPos.y = aPos.y + 0.003f;
            transform.position = aPos;
            count++;
        }
        else if (count < 100)
        {
            Vector3 aPos = transform.position;
            aPos.y = aPos.y - 0.003f;
            transform.position = aPos;
            count++;
        }
        else if (count == 100)
        {
            count = 0;
        }
    }
}
