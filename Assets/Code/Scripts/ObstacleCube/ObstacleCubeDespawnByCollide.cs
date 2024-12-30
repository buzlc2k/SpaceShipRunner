using System.Collections.Generic;
using UnityEngine;

public class ObstacleCubeDespawnByCollide : ObjDespawnByCollide
{
    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<ObstacleCubeCtrl>();
    }
}