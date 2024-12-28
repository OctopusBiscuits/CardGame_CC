using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCameraShakeOnAttack : MonoBehaviour
{
    public float duration = 0.0f;
    public float multiplier = 0.0f;

    Vector3 mainPos;
    // Start is called before the first frame update
    void Start()
    {
        mainPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (duration > 0.0f)
        {
            
            transform.position = mainPos + Random.insideUnitSphere * multiplier;

            duration -= Time.deltaTime;
        }
        else
        {
            transform.position = mainPos;
            multiplier = 0.0f;
        }
    }

    public void shake()
    {
        duration = 1.0f;
        multiplier = 1.0f;
    }
}