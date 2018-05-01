using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IShootable
{
    void shoot(bool isInfiniteAmmo);

    bool NeedsReload();

    void reload();


}