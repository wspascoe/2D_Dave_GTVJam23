using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 15;

    public event Action<float> OnDamage;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void DealDamage(float damage)
    {
        if (currentHealth == 0) { return; }

        currentHealth = Mathf.Max(currentHealth - damage, 0);

        OnDamage?.Invoke(currentHealth);
    }

    public float GetHealth()
    {
        currentHealth = maxHealth;
        return currentHealth;
    }
}
