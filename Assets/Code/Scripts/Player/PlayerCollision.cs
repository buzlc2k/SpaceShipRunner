using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived class extending ObjChangeTagCollision that define Player's collide calculating logic.
/// </summary>
public class PlayerCollision : ObjCollision
{
    protected override object GetObjCtrl()
    {
        return PlayerCtrl.Instance;
    }

    protected override void SetObjCollisionConfig()
    {
        objCollisionConfig = PlayerCtrl.Instance.playerConfig.PlayerCollisionConfig;
    }

    protected override void OnEnterCollide()
    {
        base.OnEnterCollide();
        
        Observer.PostEvent(EventID.Player_Collide, new KeyValuePair<EventParameterType, object>(EventParameterType.Player_Collide_PlayerObject, this.transform.parent.gameObject));
        ((ObjDespawnByCollide)((PlayerCtrl)GetObjCtrl()).playerDespawning).SetObjectCanDespawn();
    }
}