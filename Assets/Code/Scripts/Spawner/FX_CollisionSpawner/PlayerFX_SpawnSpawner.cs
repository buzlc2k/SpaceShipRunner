using UnityEngine;
using System;
using System.Collections.Generic;

public class PlayerFX_SpawnSpawner : StaticVFX_Spawner
{

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        spawnVFX_Delegate ??= param => {
            if (param.Key != EventParameterType.ChangeGameState_GameState) return;
            
            if(param.Value.Equals(GameState.Restarting))
                SpawnVFX();
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.ChangeGameState, spawnVFX_Delegate);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.ChangeGameState, spawnVFX_Delegate);
    }
}