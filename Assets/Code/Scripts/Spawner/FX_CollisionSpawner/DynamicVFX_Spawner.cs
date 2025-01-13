using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class DynamicVFX_Spawner : VFX_Spawner
{
    protected void SpawnVFX(GameObject objectSpawnVFX){
         Tuple<Vector3, Quaternion> spawnData = GetSpawnData(objectSpawnVFX);

        Spawn(spawnData.Item1, spawnData.Item2);
    }

    private Tuple<Vector3, Quaternion> GetSpawnData(GameObject objectSpawnVFX){
        var spawnPosition = objectSpawnVFX.transform.position;
        var spawnRotation = Quaternion.identity;

        return Tuple.Create<Vector3, Quaternion>(spawnPosition, spawnRotation);
    }

    private void Spawn(Vector3 spawnPosition, Quaternion spawnRotation){
        VFX_Poolers.Get(spawnPosition, spawnRotation);
    }
}