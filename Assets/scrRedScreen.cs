using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scrRedScreen : MonoBehaviour
{
    [SerializeField] private Image redS;
    [SerializeField] private Color myRed;
    public float additionT = 0.035f;
    public float count = 0.0f;
    float reverser = 1.0f;
    public scrPlayerScript playerScript;
    void start()
    {
        myRed.r = 1;
        myRed.g = 0;
        myRed.b = 0;
        myRed.a = 0;
        

    }

    void FixedUpdate()
    {
        redS.color = myRed;
        if (playerScript.beingAttacked == true)
        {
            myRed.a = count;
            count += (reverser * additionT);
            if (count > 0.6)
            {
                reverser = -1.0f;
            }

            else if (count < 0)
            {
                reverser = 1.0f;
            }


        }


        else
        {
            count = 0;
            myRed.a = 0;
        }
    }
}
