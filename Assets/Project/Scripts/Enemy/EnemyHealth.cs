using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable<float>
{
    public float health;
    public float currentHealth;


    void Start()
    {
        currentHealth = health;
    }

   void OnEnable()
    {
        currentHealth = health;
    }

    public void Damage(float pain)
    {
        currentHealth -= pain;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
