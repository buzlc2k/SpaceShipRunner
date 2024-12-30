using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived class extending ObjChangeTagCollision that define Player's collide calculating logic.
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

    protected override void OnEnterCollide()
    {
        base.OnEnterCollide();
        
        Observer.PostEvent(EventID.Player_Collide, new KeyValuePair<EventParameterType, object>(EventParameterType.Player_Collide_PlayerObject, this.transform.parent.gameObject));
        ((ObjDespawnByCollide)((PlayerCtrl)GetObjCtrl()).playerDespawning).SetObjectCanDespawn();
    }
}