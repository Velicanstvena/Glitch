using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 500f;
    [SerializeField] GameObject deathVFX;

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        TriggerDeathVFX();
        Destroy(gameObject);
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) { return; }

        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(explosion, 2f);
    }
}
