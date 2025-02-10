using System.Collections.Generic;
using UnityEngine;

public class CoinCubeCollision : ObjCollision
{
    protected override object GetObjCtrl()
    {
        return transform.parent.GetComponent<CoinCubeCtrl>();
    }

    protected override void SetObjCollisionConfig()
    {
        objCollisionConfig = ((CoinCubeCtrl)GetObjCtrl()).coinCubeConfig.CoinCollisionConfig;
    }

    protected override void OnEnterCollide()
    {
        base.OnEnterCollide();
        
        Observer.PostEvent(EventID.Player_TakeCoin, new KeyValuePair<EventParameterType, object>(EventParameterType.Player_TakeCoin_Null, null));
        ((ObjDespawnByCollide)((CoinCubeCtrl)GetObjCtrl()).coinCubeDespawning).SetObjectCanDespawn();
    }
}