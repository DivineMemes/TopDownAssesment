using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour
{

    IDamageable<float> damageable;
    public float damage;
    public float speed;
    GameObject player;
    Rigidbody rb;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Chase();
    }

    void Chase()
    {
        Vector3 dir = (player.transform.position - gameObject.transform.position).normalized;
        Vector3 desiredVel = dir * speed;
        rb.AddForce(desiredVel - rb.velocity);

        transform.LookAt(player.transform.position);
    }


    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Player")
        {
            damageable = other.collider.GetComponent<IDamageable<float>>();
            if(damageable != null)
            {
                damageable.Damage(damage);
                Destroy(gameObject);
            }
        }
    }
}
