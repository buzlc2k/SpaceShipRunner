using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived class extending ObjCollision that define Player's collide calculating logic.
/// </summary>
public class PlayerCollision : ObjCollision
{    
    protected override void LoadValue()
    {
        base.LoadValue();
        colliderRadius = ((PlayerCtrl)GetObjCtrl()).playerConfig.InitialColliderRadius;
        tagOfCollisionableObject = ((PlayerCtrl)GetObjCtrl()).playerConfig.InitialTagOfCollisionableObject;
        tagOfObject = ((PlayerCtrl)GetObjCtrl()).playerConfig.InitialTagOfObject;
    }

    protected override object GetObjCtrl()
    {
        return PlayerCtrl.Instance;
    }
}