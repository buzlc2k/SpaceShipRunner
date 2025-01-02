using UnityEngine;
using System;
using System.Collections.Generic;

public class PlayerFX_CollisionSpawner : FX_CollisionSpawner
{

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        spawnFX_CollisionDelegate ??= param => {
            if (param.Key != EventParameterType.Player_Collide_PlayerObject) return;
            SpawnFX_Collision((GameObject)param.Value);
        };
    }

    protected override void AddListenerToObsever()
    {
        base.AddListenerToObsever();

        Observer.AddListener(EventID.Player_Collide, spawnFX_CollisionDelegate);
    }

    protected override void RemoveListenerFromObsever()
    {
        base.RemoveListenerFromObsever();

        Observer.RemoveListener(EventID.Player_Collide, spawnFX_CollisionDelegate);
    }
}