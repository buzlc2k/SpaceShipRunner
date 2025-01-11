using UnityEngine;
using System;
using System.Collections.Generic;

public class B_CubeFX_CollisionSpawner : FX_CollisionSpawner
{
    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        spawnFX_CollisionDelegate ??= param => {
            if (param.Key != EventParameterType.B_Cube_Collide_CubeObject) return;
            SpawnFX_Collision((GameObject)param.Value);
        };
    }

    

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.B_Cube_Collide, spawnFX_CollisionDelegate);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.B_Cube_Collide, spawnFX_CollisionDelegate);
    }
}