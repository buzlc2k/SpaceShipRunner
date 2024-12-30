using System.Collections.Generic;
using UnityEngine;

public class CoinCubeDespawnByCollide : ObjDespawnByCollide
{
    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<CoinCubeCtrl>();
    }
}