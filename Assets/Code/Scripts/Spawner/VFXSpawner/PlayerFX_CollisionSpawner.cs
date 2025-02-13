using UnityEngine;
using System;
using System.Collections.Generic;

public class PlayerFX_CollisionSpawner : DynamicVFX_Spawner
{

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        spawnVFX_Delegate ??= param => {
            SpawnVFX((GameObject)param.Value);
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.Player_Collide, spawnVFX_Delegate);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.Player_Collide, spawnVFX_Delegate);
    }
}