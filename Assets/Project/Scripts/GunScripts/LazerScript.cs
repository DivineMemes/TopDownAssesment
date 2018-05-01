using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour, IShootable
{
    IDamageable<float> damageable;
    public LayerMask layer;
    public float ammo;
    public float reloadTime;
    public float painFactor;
    public float currentAmmo;
    bool IsReloading;

    //int x = 0;
    void Start()
    {
        currentAmmo = ammo;
    }
    public bool NeedsReload()
    {
        return currentAmmo <= 0;
    }

    public void shoot(bool isInfinite)
    {
        RaycastHit hit;
        if (Input.GetMouseButton(0) && currentAmmo > 0)
        {
            Physics.Raycast(transform.position, transform.forward, out hit, 100f, layer);
            //LineRenderer line = new GameObject("Lazer " + x.ToString()).AddComponent<LineRenderer>();

            if (!isInfinite)
            { currentAmmo -= 1f; }

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Enemy")
                {
                    damageable = hit.collider.GetComponent<IDamageable<float>>();

                    if (damageable != null)
                    {
                        damageable.Damage(painFactor);
                    }
                }
            }
            
        }
    }

    public void reload()
    {
        if(Input.GetKeyDown(KeyCode.R) && !IsReloading)
        {
            StartCoroutine(DoReload());
        }
    }

    IEnumerator DoReload()
    {
        IsReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = ammo;
        IsReloading = false;
    }

}
