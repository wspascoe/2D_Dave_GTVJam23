using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] Health playerHealth;

    float currentHealth;
    float maxHealth;

    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        playerHealth.OnDamage += UpdateHealth;
        currentHealth = playerHealth.GetHealth();
        maxHealth = currentHealth;
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    private void UpdateHealth(float amount)
    {
        currentHealth = amount;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
