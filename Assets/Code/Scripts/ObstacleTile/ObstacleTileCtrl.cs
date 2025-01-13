using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleTileCtrl : ButMonobehavior, IPooled
{
    public Transform[] obstacleCubes;
    public ObjMovement obstacleTileMovement;
    public ObjDespawning obstacleTileDespawn;
    public ObstacleTileConfig obstacleTileConfig;

    protected override void LoadComponents() {
        base.LoadComponents();
        
        obstacleCubes = GetComponentsInChildren<ObstacleCubeCtrl>()
               .Select(obstacleCubeCtrl => obstacleCubeCtrl.transform)
               .ToArray();
        if(obstacleTileMovement == null) obstacleTileMovement = GetComponentInChildren<ObjMovement>();
        if(obstacleTileDespawn == null) obstacleTileDespawn = GetComponentInChildren<ObjDespawning>();
    }

    protected override void ResetValue()
    {
        foreach(Transform child in transform){
            if(!child.gameObject.activeSelf) child.gameObject.SetActive(true);
        }

        for(int i = 0; i < obstacleCubes.Length; i++){
            obstacleCubes[i].localPosition = obstacleTileConfig.ObstacleCubePosition[i];
        }

        base.ResetValue();        
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        ReleaseCallback?.Invoke(gameObject);
    }

    public Action<GameObject> ReleaseCallback { get; set; }
}