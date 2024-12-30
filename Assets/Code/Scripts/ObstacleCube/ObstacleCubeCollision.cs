using System.Collections.Generic;
using UnityEngine;

public class ObstacleCubeCollision : ObjCollision
{ 
    protected override void LoadValue()
    {
        base.LoadValue();
        colliderRadius = ((ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeConfig.InitialColliderRadius;
        tagOfCollisionableObject = ((ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeConfig.InitialTagOfCollisionableObject;
        tagOfObject = ((ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeConfig.InitialTagOfObject;
    }

    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<ObstacleCubeCtrl>();
    }

    protected override void OnEnterCollide()
    {
        base.OnEnterCollide();

        if(tagOfObject.Equals(ObjTagCollision.Obstacle_Black))
            Observer.PostEvent(EventID.B_Cube_Collide, new KeyValuePair<EventParameterType, object>(EventParameterType.B_Cube_Collide_CubeObject, this.transform.parent.gameObject));
        else
             Observer.PostEvent(EventID.W_Cube_Collide, new KeyValuePair<EventParameterType, object>(EventParameterType.W_Cube_Collide_CubeObject, this.transform.parent.gameObject));
        
        ((ObjDespawnByCollide)((ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeDespawn).SetObjectCanDespawn();
    }
}