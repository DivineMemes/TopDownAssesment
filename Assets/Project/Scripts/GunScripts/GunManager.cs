using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{

    IShootable[] currentGun;
    int Index;
    public bool isInfinite = false;
    public float InfiniteAmmoTime;

    void Start()
    {
        currentGun = GetComponents<IShootable>();
    }
    void Update()
    {
        
        weaponSwitch();
        if (!currentGun[Index].NeedsReload())
        {
            currentGun[Index].shoot(isInfinite);
        }
        else
        {
            currentGun[Index].reload();
        }

        if(isInfinite)
        {
            StartCoroutine(infniteAmmo());
        }
        //Debug.Log("the length if the array is " + currentGun.Length);
        //Debug.Log("The current index is " + Index);
    }


    void weaponSwitch()
    {

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)//forward
        {
            Index++;
            if (Index > 1)
            {
                Index = 1;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) //backward
        {
            Index--;
            if (Index < 0)
            {
                Index = 0;
            }
        }
    }

    IEnumerator infniteAmmo()
    {
        yield return new WaitForSeconds(InfiniteAmmoTime);
        isInfinite = false;
    }

}