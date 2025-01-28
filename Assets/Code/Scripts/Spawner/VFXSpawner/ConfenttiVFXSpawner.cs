using UnityEngine;
using System;
using System.Collections.Generic;

public class ConfenttiVFXSpawner : StaticVFX_Spawner
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

        Observer.AddListener(EventID.CoinItem_BuySuccess, spawnVFX_Delegate);
        Observer.AddListener(EventID.SpaceShipItem_BuySuccess, spawnVFX_Delegate);
        Observer.AddListener(EventID.ADS_WatchFullAds, spawnVFX_Delegate);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.CoinItem_BuySuccess, spawnVFX_Delegate);
        Observer.RemoveListener(EventID.SpaceShipItem_BuySuccess, spawnVFX_Delegate);
        Observer.RemoveListener(EventID.ADS_WatchFullAds, spawnVFX_Delegate);
    }
}