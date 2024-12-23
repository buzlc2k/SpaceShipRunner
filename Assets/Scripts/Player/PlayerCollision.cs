using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived class extending ObjChangeTagCollision that define Player's collide calculating logic.
/// </summary>
public class PlayerCollision : ObjChangeTagCollision
{    
    protected override void LoadValue()
    {
        base.LoadValue();
        colliderRadius = ((PlayerCtrl)GetObjCtrl()).playerConfig.InitialColliderRadius;
        tagOfCollisionableObject = ((PlayerCtrl)GetObjCtrl()).playerConfig.InitialTagOfCollisionableObject;
        tagOfObject = ((PlayerCtrl)GetObjCtrl()).playerConfig.InitialTagOfObject;
        targetTagOfCollisionableObject = ((PlayerCtrl)GetObjCtrl()).playerConfig.InitialTargetTagOfCollisionableObject;
        targetTagOfOfject = ((PlayerCtrl)GetObjCtrl()).playerConfig.InitialTargetTagOfObject;
    }

    protected override object GetObjCtrl()
    {
        return PlayerCtrl.Instance;
    }
}