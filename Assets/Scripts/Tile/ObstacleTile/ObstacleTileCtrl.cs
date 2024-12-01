using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleTileCtrl : ButMonobehavior, IPooled
{
    public Transform[] obstacleCubes;
    public ObjMovement obstacleTileMovement;
    public ObjDespawn obstacleTileDespawn;
    public ObstacleTileConfig obstacleTileConfig;

    protected override void LoadComponents() {
        base.LoadComponents();
        
        obstacleCubes = GetComponentsInChildren<ObstacleCubeCtrl>()
               .Select(obstacleCubeCtrl => obstacleCubeCtrl.transform)
               .ToArray();
        if(obstacleTileMovement == null) obstacleTileMovement = GetComponentInChildren<ObjMovement>();
        if(obstacleTileDespawn == null) obstacleTileDespawn = GetComponentInChildren<ObjDespawn>();
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        foreach(Transform child in transform){
            if(!child.gameObject.activeSelf) child.gameObject.SetActive(true);
        }
    }

    public Action<GameObject> ReleaseCallback { get; set; }
}

