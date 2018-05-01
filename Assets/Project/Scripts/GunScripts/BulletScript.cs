using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    IDamageable<float> damageable;
    public float painFactor;
    public float lifeTime;


    void Awake()
    {
        StartCoroutine(killBullet());
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Enemy")
        {
            damageable = other.collider.GetComponent<IDamageable<float>>();
            if (damageable != null)
            {
                damageable.Damage(painFactor);
            }
        }
        Destroy(gameObject);
    }



    IEnumerator killBullet()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}

