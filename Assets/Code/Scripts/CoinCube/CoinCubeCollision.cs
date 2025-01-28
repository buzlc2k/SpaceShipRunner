using System.Collections.Generic;
using UnityEngine;

public class CoinCubeCollision : ObjCollision
{
    protected override void LoadValue()
    {
        base.LoadValue();

        colliderRadius = ((CoinCubeCtrl)GetObjCtrl()).coinCubeConfig.InitialColliderRadius;
        tagOfCollisionableObject = ((CoinCubeCtrl)GetObjCtrl()).coinCubeConfig.InitialTagOfCollisionableObject;
        tagOfObject = ((CoinCubeCtrl)GetObjCtrl()).coinCubeConfig.InitialTagOfObject;
    }

    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<CoinCubeCtrl>();
    }

    protected override void OnEnterCollide()
    {
        base.OnEnterCollide();
        
        Observer.PostEvent(EventID.Player_TakeCoin, new KeyValuePair<EventParameterType, object>(EventParameterType.Player_TakeCoin_Null, null));
        ((ObjDespawnByCollide)((CoinCubeCtrl)GetObjCtrl()).coinCubeDespawning).SetObjectCanDespawn();
    }
}