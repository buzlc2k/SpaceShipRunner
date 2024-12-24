using UnityEngine;
using System;
using System.Collections.Generic;

public class W_CubeFX_CollisionSpawner : FX_CollisionSpawner
{
    protected override void OnDisable()
    {
        base.OnDisable();

        Observer.RemoveListener(EventID.W_Cube_Collide, spawnFX_CollisionDelegate);
    }

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        spawnFX_CollisionDelegate ??= param => {
            if (param.Key != EventParameterType.W_Cube_Collide_CubeObject) return;
            SpawnFX_Collision((GameObject)param.Value);
        };

        Observer.AddListener(EventID.W_Cube_Collide, spawnFX_CollisionDelegate);
    }
}