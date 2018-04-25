using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGunScript : MonoBehaviour, IShootable
{
    public GameObject bullet;
    public Rigidbody rb;
    Vector3 myPos;
    public int maxAmmo;
    public int currentAmmo;
    public float reloadTime;
    public float speed;


    bool IsReloading;

    public float warmUp;
    float o_warmup;

    void Update()
    {
        myPos = gameObject.transform.position;
    }
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
                GameObject newBullet = Instantiate(bullet, myPos, Quaternion.identity);
                newBullet.GetComponent<Rigidbody>().velocity = (transform.forward * speed);
                currentAmmo--;
            }
        }
        else
        {
            warmUp = o_warmup;
        }
    }

    public void reload()
    {
        if (Input.GetKeyDown(KeyCode.R) && !IsReloading)
        {
            StartCoroutine(reloading());
        }
        
    }

    public IEnumerator reloading()
    {
        IsReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        warmUp = o_warmup;
        IsReloading = false;
    }
}
