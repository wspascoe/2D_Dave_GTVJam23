using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] Health playerHealth;

    int currentHealth;
    int maxHealth;

    public void SetupHealth()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        playerHealth.OnDamage += UpdateHealth;
        currentHealth = playerHealth.GetHealth();
        maxHealth = currentHealth;
        Debug.Log(currentHealth + "/" + maxHealth);
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    private void UpdateHealth(int amount)
    {
       
    }
}
