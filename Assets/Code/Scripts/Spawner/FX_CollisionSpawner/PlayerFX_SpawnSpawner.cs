using UnityEngine;
using System;
using System.Collections.Generic;

public class PlayerFX_SpawnSpawner : StaticVFX_Spawner
{

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        spawnVFX_Delegate ??= param => {
            SpawnVFX();
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.EnterGameRestartingState, spawnVFX_Delegate);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.EnterGameRestartingState, spawnVFX_Delegate);
    }
}