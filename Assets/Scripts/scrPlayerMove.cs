using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class scrPlayerMove : MonoBehaviour
{
    public InputActionReference up;
    public InputAction inputAct;
    public PlayerInput theInput;
    bool forward = false;
    bool backward = false;
    bool right = false;
    bool left = false;
    int fcount = 0;
    int bcount = 0;
    int lcount = 0;
    int rcount = 0;
    bool movingRN = false;
    public int currentLocation;
    // Start is called before the first frame update
    void Start()
    {
        inputAct = GetComponent<PlayerInput>().actions.FindAction("Up");
        inputAct.Enable();

        rcount = 0;
        lcount = 0;
        fcount = 0;
        bcount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (forward && fcount < 54)
        {
            Vector3 aPosition = transform.position;
            aPosition.z += 0.05f;
            transform.position = aPosition;
            fcount++;
        }
        if (fcount == 54)
        {
            forward = false;
            fcount = 0;
            movingRN = false;
        }

        if (backward && bcount < 54)
        {
            Vector3 aPosition = transform.position;
            aPosition.z -= 0.05f;
            transform.position = aPosition;
            bcount++;
        }
        if (bcount == 54)
        {
            backward = false;
            bcount = 0;
            movingRN = false;
        }

        if (left && lcount < 56)
        {
            Vector3 aPosition = transform.position;
            aPosition.x -= 0.0625f;
            transform.position = aPosition;
            lcount++;
            
        }
        if (lcount == 56)
        {
            left = false;
            lcount = 0;
            movingRN = false;
        }

        if (right && rcount < 56)
        {
            Vector3 aPosition = transform.position;
            aPosition.x += 0.0625f;
            transform.position = aPosition;
            rcount++;
        }
        if (rcount == 56)
        {
            right = false;
            rcount = 0;
            movingRN = false;
        }
    }

    void OnUp()
    {
        if (!movingRN)
        {
            if (transform.position.x == 0 && transform.position.z < 2.60)
            {
                forward = true;
                movingRN = true;
            }
            else if (transform.position.x == -3.5 && (transform.position.z > -0.1 && transform.position.z < 0.1))
            {
                forward = true;
                movingRN = true;
            }
               
        }
        
    }

    void OnDown()
    {
        if(!movingRN)
        {
            if (transform.position.x == 0 && transform.position.z > -2.6)
            {
                backward = true;
                movingRN = true;
            }
            else if (transform.position.x == -3.5 && transform.position.z > 2.6)
            {
                movingRN=true;
                backward = true;
            }
            
        }
        
    }

    void OnLeft()
    {
        if (!movingRN)
        {
            if ((transform.position.z < 0.1 && transform.position.z > -0.1) && transform.position.x > -3.5)
            {
                left = true;
                movingRN = true;
            }
            else if ((transform.position.z < 2.8 && transform.position.z > 2.6) && transform.position.x > -7)
            {
                left = true;
                movingRN = true;
            }


        }
        
    }

    void OnRight()
    {
        if (!movingRN)
        {
            if ((transform.position.z < 0.1 && transform.position.z > -0.1) && transform.position.x < 3.5)
            {
                right = true;
                movingRN = true;
            }
            else if ((transform.position.z < 2.8 && transform.position.z > 2.6) && transform.position.x < 0)
            {
                right = true;
                movingRN = true;
            }
            
        }
    }
}
