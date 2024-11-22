using UnityEngine;

public class ObstacleCubeCollision : ObjCollision
{    
    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<ObstacleCubeCtrl>();
    }
}