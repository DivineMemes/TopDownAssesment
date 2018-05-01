using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : MonoBehaviour
{
    public float speed;
    public float radius;
    GameObject player;
    Rigidbody rb;
    bool playerNear;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (!playerNear)
        { 
            Chase();
        }
        else
        {
            Explode();
        }
        PlayerCheck();
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

    }
}