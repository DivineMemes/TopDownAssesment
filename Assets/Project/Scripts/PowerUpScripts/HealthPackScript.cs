using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackScript : MonoBehaviour
{
    PlayerHealth health;
    public float healthAdd;
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    void Update()
    {
        AttractAttention();
    }

    void AttractAttention()
    {
        gameObject.transform.rotation *= Random.rotation;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            health.currentHealth += healthAdd;
            Destroy(gameObject);
        }
    }

}