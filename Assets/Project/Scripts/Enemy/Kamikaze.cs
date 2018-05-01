using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : MonoBehaviour
{
    public float speed;
    public float radius;
    public float blastRadius;
    public float damage;
    public float fuseTime;
    GameObject player;
    Rigidbody rb;
    public bool playerNear;

    IDamageable<float> damageable;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        PlayerCheck();
        if (!playerNear)
        { 
            Chase();
        }
        else
        {
            Explode();
        }
    }

    void Chase()
    {
        Vector3 dir = (player.transform.position - gameObject.transform.position).normalized;
        Vector3 desiredVel = dir * speed;
        rb.AddForce(desiredVel - rb.velocity);

        transform.LookAt(player.transform.position);


    }

    void PlayerCheck()
    {
       
        //int hoodsize = 0;
        Collider[] hood = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider guyInHood in hood)
        {
            if(guyInHood.tag == "Player")
            {
                playerNear = true;
            }
        }
    }
    void Explode()
    {
        rb.velocity =new Vector3(0,0,0);
        Collider[] hood = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider guyInHood in hood)
        {
            if (guyInHood.tag == "Player")
            {
                damageable = guyInHood.GetComponent<IDamageable<float>>();
                if (damageable != null)
                {
                    fuseTime -= Time.deltaTime;
                    if(fuseTime <= 0)
                    {
                        damageable.Damage(damage);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}