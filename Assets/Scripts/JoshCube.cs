using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using TMPro;
public class JoshCube : MonoBehaviour
{
    public static int tickCount = 4;
    public string enemyName;
    public TextMeshProUGUI text;
    public int health = 10;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, 0.1f, 0);

        if (health == 0)
        {
            Destroy(gameObject);
        }
        text.text = enemyName + ", Health : " + health;
    }

    private void FixedUpdate()
    {
        if (count < 50)
        {
            Vector3 aPos = transform.position;
            aPos.y = aPos.y + 0.01f;
            transform.position = aPos;
            count++;
        }
        else if (count < 100)
        {
            Vector3 aPos = transform.position;
            aPos.y = aPos.y - 0.01f;
            transform.position = aPos;
            count++;
        }
        else if (count == 100)
        {
            count = 0;
        }

    }
}
