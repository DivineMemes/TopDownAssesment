using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunScript : MonoBehaviour, IShootable
{
    IShootable shotGun;

    public bool NeedsReload()
    {
        return false;
    }

    public void shoot()
    {

    }

    public void reload()
    {

    }
}
