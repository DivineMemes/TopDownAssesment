using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{

    IShootable currentGun;

    void Update()
    {
        if(!currentGun.NeedsReload())
        {
            currentGun.shoot();
        }
        else
        {
            currentGun.reload();
        }
    }



}

public interface IShootable
{
    void shoot();

    bool NeedsReload();

    void reload();


}