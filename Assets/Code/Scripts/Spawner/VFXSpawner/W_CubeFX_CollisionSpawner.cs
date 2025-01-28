using UnityEngine;
using System;
using System.Collections.Generic;

public class W_CubeFX_CollisionSpawner : DynamicVFX_Spawner
{
    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        spawnVFX_Delegate ??= param => {
            if (param.Key != EventParameterType.W_Cube_Collide_CubeObject) return;
            SpawnVFX((GameObject)param.Value);
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.W_Cube_Collide, spawnVFX_Delegate);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.W_Cube_Collide, spawnVFX_Delegate);
    }
}