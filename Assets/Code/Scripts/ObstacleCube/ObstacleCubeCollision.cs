using System.Collections.Generic;
using UnityEngine;

public class ObstacleCubeCollision : ObjCollision
{
    protected override object GetObjCtrl()
    {
        return transform.parent.GetComponent<ObstacleCubeCtrl>();
    }

    protected override void SetObjCollisionConfig()
    {
        objCollisionConfig = ((ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeConfig.ObstacleCubeCollisionConfig;
    }

    protected override void OnEnterCollide()
    {
        base.OnEnterCollide();

        if(objCollisionConfig.TagOfObject.Equals(ObjTagCollision.Obstacle_Black))
            Observer.PostEvent(EventID.B_Cube_Collide, new KeyValuePair<EventParameterType, object>(EventParameterType.B_Cube_Collide_CubeObject, this.transform.parent.gameObject));
        else
            Observer.PostEvent(EventID.W_Cube_Collide, new KeyValuePair<EventParameterType, object>(EventParameterType.W_Cube_Collide_CubeObject, this.transform.parent.gameObject));

        ((ObjDespawnByCollide)((ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeDespawn).SetObjectCanDespawn();
    }
}