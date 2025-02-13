using System.Collections.Generic;
using UnityEngine;

public class CoinCubeCollision : NonPlayerObjCollision
{
    protected override object GetObjCtrl()
    {
        return transform.parent.GetComponent<CoinCubeCtrl>();
    }

    protected override void SetObjCollisionConfig()
    {
        objCollisionConfig = ((CoinCubeCtrl)GetObjCtrl()).coinCubeConfig.CoinCollisionConfig;
    }

    public override void OnEnterCollide(ObjCollision sender)
    {     
        Observer.PostEvent(EventID.Player_TakeCoin, new KeyValuePair<EventParameterType, object>(EventParameterType.Player_TakeCoin_Null, null));
        ((ObjDespawnByCollide)((CoinCubeCtrl)GetObjCtrl()).coinCubeDespawning).SetObjectCanDespawn();
    }
}