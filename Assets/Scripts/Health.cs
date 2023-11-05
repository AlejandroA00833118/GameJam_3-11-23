using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;

    public float currentHealth;
    public float maxHealth;

    void Start()
    {
        
    }

    void Update()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
