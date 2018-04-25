using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunScript : MonoBehaviour, IShootable
{
    IDamageable<float> damageable;
    public GameObject bullet;
    public Rigidbody rb;
    public int ammoMax;
    int currentAmmo;


    void Start()
    {
        currentAmmo = ammoMax;
    }

    public bool NeedsReload()
    {
        return currentAmmo < ammoMax;
    }

    public void shoot()
    {
        if(Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {

        }
    }

    public void reload()
    {

    }
}
