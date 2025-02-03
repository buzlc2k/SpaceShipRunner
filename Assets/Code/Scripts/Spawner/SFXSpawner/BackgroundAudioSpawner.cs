using UnityEngine;
using System;
using System.Collections.Generic;

public class BackgroundAudioSpawner : Audio_Spawner
{
    protected override void Start()
    {
        base.Start();

        SpawnAudio();
    }
}