using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable<float>
{
    public float maxHealth;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(float damageTaken)
    {
        currentHealth -= damageTaken;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }


}
