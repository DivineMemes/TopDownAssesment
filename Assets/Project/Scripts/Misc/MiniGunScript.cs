using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGunScript : MonoBehaviour, IShootable
{
    IShootable miniGun;
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
