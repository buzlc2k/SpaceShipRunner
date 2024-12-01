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
}