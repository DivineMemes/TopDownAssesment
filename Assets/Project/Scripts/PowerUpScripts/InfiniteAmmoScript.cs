using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteAmmoScript : MonoBehaviour
{

    GunManager guns;
    PooledObject pooledObject;
    void Start()
    {
        pooledObject = GetComponent<PooledObject>();
        //guns = GameObject.FindGameObjectWithTag("Player").GetComponent<GunManager>();
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
            guns = other.collider.GetComponent<GunManager>();
            guns.isInfinite = true;
            pooledObject.returnToPool();
            // Destroy(gameObject);
        }
    }
}