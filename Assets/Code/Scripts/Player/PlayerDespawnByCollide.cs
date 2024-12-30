using System.Collections.Generic;
using UnityEngine;

public class PlayerDespawnByCollide : ObjDespawnByCollide
{
    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<PlayerCtrl>();
    }
}