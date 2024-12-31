using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class scrHealthBar : MonoBehaviour
{
    [SerializeField] private Image healthbar;
    public Camera main;
    float target;
    float reduction = 2f;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   

    public void UpdateHealthBar(float fullHeatlh, float currentHealth)
    {
        target = currentHealth / fullHeatlh;
        healthText.text = currentHealth + "/" + fullHeatlh;

    }

    void Update()
    {
        healthbar.fillAmount = Mathf.MoveTowards(healthbar.fillAmount, target, reduction * Time.deltaTime);
    }
}
