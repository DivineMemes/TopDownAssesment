using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lurker : MonoBehaviour
{
    IDamageable<float> damageable;
    public float damage;
    PooledObject pooledObject;

    void Start()
    {
        pooledObject = GetComponent<PooledObject>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            damageable = other.collider.GetComponent<IDamageable<float>>();
            if (damageable != null)
            {
                damageable.Damage(damage);
                //Destroy(gameObject);
                pooledObject.returnToPool();
            }
        }
    }
}
