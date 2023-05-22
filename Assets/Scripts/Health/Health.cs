using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 15;

    public event Action<int> OnDamage;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void DealDamage(int damage)
    {
        if (currentHealth == 0) { return; }

        currentHealth = Mathf.Max(currentHealth - damage, 0);

        OnDamage?.Invoke(currentHealth);
    }

    public int GetHealth()
    {
        currentHealth = maxHealth;
        return currentHealth;
    }
}
