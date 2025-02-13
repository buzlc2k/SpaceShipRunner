using UnityEngine;
using System;
using System.Collections.Generic;

public class W_CubeFX_CollisionSpawner : DynamicVFX_Spawner
{
    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        spawnVFX_Delegate ??= param => {
            if(((ObjCollision)param.Value).ObjCollisionConfig.TagOfObject.Equals(ObjTagCollision.Obstacle_White))
                SpawnVFX(((ObjCollision)param.Value).gameObject);
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.ObstacleCube_Collide, spawnVFX_Delegate);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.ObstacleCube_Collide, spawnVFX_Delegate);
    }
}