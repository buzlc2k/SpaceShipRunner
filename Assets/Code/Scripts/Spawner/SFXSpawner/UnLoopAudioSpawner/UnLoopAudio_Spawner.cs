using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class UnLoopAudio_Spawner : Audio_Spawner
{
    protected Action<KeyValuePair<EventParameterType, object>> spawnAudio_Delegate;

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        spawnAudio_Delegate ??= (param) => {
            SpawnAudio();
        };
    }
}