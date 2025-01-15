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
    GameObject player;
    scrPlayerScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        iText = text.GetComponent<scrInstructionText>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<scrPlayerScript>();
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
            
            thisEnemy.GetComponent<scrEnemy>().TakeDamage(5 + playerScript.damageIncrease);
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
