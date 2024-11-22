using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleTileCtrl : MonoBehaviour, IPooled
{
    public Transform[] obstacleCubes;
    public ObjMovement obstacleTileMovement;
    public ObjDespawn obstacleTileDespawn;

    private void Reset() {
        obstacleCubes = GetComponentsInChildren<ObstacleCubeCtrl>()
               .Select(obstacleCubeCtrl => obstacleCubeCtrl.transform)
               .ToArray();
        obstacleTileMovement = GetComponentInChildren<ObjMovement>();
        obstacleTileDespawn = GetComponentInChildren<ObjDespawn>();
    }
    public Action<GameObject> ReleaseCallback { get; set; }
}

