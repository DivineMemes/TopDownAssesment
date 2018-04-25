using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGunScript : MonoBehaviour, IShootable
{
    IDamageable<float> damageable;
    public GameObject bullet;
    public Rigidbody rb;
    public int maxAmmo;
    public int currentAmmo;
    public float reloadTime;

    bool IsReloading;

    public float warmUp;
    float o_warmup;


    void Start()
    {
        o_warmup = warmUp;
        currentAmmo = maxAmmo;
    }


    public bool NeedsReload()
    {
        return currentAmmo <= 0;
    }

    public void shoot()
    {
        if(Input.GetMouseButton(0) && currentAmmo > 0)
        {
            warmUp -= Time.deltaTime;
            if (warmUp <= 0)
            {
                Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
                currentAmmo--;
            }
            else if(!Input.GetMouseButton(0))
            {
                warmUp = o_warmup;
            }
        }
    }

    public void reload()
    {
        StartCoroutine(reloading());
    }

    public IEnumerator reloading()
    {
        IsReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        IsReloading = false;
    }
}
