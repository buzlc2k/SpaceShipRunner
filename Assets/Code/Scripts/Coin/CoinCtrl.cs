using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCtrl : ButMonobehavior, IPooled
{
    public Transform coinCube;
    public ObjMovement coinMovement;
    public ObjDespawning coinDespawn;
    public CoinConfig coinConfig;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        if(coinCube == null) coinCube = GetComponentInChildren<CoinCubeCtrl>().transform;
        if(coinMovement == null) coinMovement = GetComponentInChildren<ObjMovement>();
        if(coinDespawn == null) coinDespawn = GetComponentInChildren<ObjDespawning>();
    }

    public Action<GameObject> ReleaseCallback { get; set; }
}
