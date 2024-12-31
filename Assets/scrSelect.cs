using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrSelect : MonoBehaviour
{
    public bool selectMode = false;
    GameObject delete;
    public string selectedEnemy;
    public GameObject text;
    scrInstructionText iText;
    // Start is called before the first frame update
    void Start()
    {
        iText = text.GetComponent<scrInstructionText>();
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
            
            thisEnemy.GetComponent<scrEnemy>().TakeDamage(5);
            thisEnemy.GetComponent<scrCameraShakeOnAttack>().shake();
            delete = GameObject.FindWithTag("Delete");
            delete.GetComponent<scrCard>().discardCard(true);
            iText.cardsDrawn();
        }
        else
        {
            Debug.Log("Not in select mode!");
        }
        selectMode = false;
    }
}
