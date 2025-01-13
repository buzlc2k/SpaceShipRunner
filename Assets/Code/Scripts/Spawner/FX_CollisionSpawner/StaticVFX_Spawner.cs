using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class StaticVFX_Spawner : VFX_Spawner
{
    [Header("StaticVFX_Spawner")]
    [SerializeField] protected Vector3 vfxSpawnPos;

    protected void SpawnVFX(){
        VFX_Poolers.Get(vfxSpawnPos, Quaternion.identity);
    }
}