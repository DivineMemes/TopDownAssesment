using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour, IShootable
{
    IShootable lazerGun;
    LayerMask layer;
    public float ammo;
    public bool NeedsReload()
    {
        return false;
    }
    void Update()
    {
        shoot();
    }

    public void shoot()
    {
        RaycastHit hit;
        if (Input.GetMouseButton(0))
        {
            if()
            {

            }
            Physics.Raycast(transform.position, transform.forward, out hit, 100f, layer);
            
            
        }
    }

    public void reload()
    {

    }
}
