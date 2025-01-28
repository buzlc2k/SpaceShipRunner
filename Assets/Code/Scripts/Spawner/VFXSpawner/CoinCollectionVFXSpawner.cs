using UnityEngine;
using System;
using System.Collections.Generic;

public class CoinCollectionVFXSpawner : StaticVFX_Spawner
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

        Observer.AddListener(EventID.FinishCalculateTotalCoin, spawnVFX_Delegate);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.FinishCalculateTotalCoin, spawnVFX_Delegate);
    }
}