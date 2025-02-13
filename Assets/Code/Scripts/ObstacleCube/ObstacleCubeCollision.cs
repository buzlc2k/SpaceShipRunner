using System.Collections.Generic;
using UnityEngine;

public class ObstacleCubeCollision : NonPlayerObjCollision
{
    protected override object GetObjCtrl()
    {
        return transform.parent.GetComponent<ObstacleCubeCtrl>();
    }

    protected override void SetObjCollisionConfig()
    {
        objCollisionConfig = ((ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeConfig.ObstacleCubeCollisionConfig;
    }

    public override void OnEnterCollide(ObjCollision sender)
    {
        Observer.PostEvent(EventID.ObstacleCube_Collide, new KeyValuePair<EventParameterType, object>(EventParameterType.ObstacleCube_Collide_ObjCollision, this));

        ((ObjDespawnByCollide)((ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeDespawn).SetObjectCanDespawn();
    }
}