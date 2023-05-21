using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private Animator anim;
    Health health;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
    }


    private void Start()
    {
        health.OnDamage += Damage;
    }

    private void Damage(int healthAmount)
    {
        if(healthAmount > 0)
        {
            StartCoroutine("DamageDealt");
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetTrigger("Death");
        Destroy(gameObject, 3f);
    }

    private IEnumerator DamageDealt()
    {
        anim.SetBool("GetHit", true);
        yield return new WaitForSeconds(2f);
        anim.SetBool("GetHit", false);

    }
}
