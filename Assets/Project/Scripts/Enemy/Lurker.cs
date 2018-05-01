using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lurker : MonoBehaviour
{
    IDamageable<float> damageable;
    public float damage;


    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            damageable = other.collider.GetComponent<IDamageable<float>>();
            if (damageable != null)
            {
                damageable.Damage(damage);
                //Destroy(gameObject);
            }
        }
    }
}
