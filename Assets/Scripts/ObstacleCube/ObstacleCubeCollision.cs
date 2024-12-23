using UnityEngine;

public class ObstacleCubeCollision : ObjChangeTagCollision
{ 
    protected override void LoadValue()
    {
        base.LoadValue();
        colliderRadius = ((ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeConfig.InitialColliderRadius;
        tagOfCollisionableObject = ((ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeConfig.InitialTagOfCollisionableObject;
        tagOfObject = ((ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeConfig.InitialTagOfObject;
        targetTagOfCollisionableObject = ((ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeConfig.InitialTargetTagOfCollisionableObject;
        targetTagOfOfject = ((ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeConfig.InitialTargetTagOfObject;
    }

    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<ObstacleCubeCtrl>();
    }
}