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

    protected override void ResetValue()
    {
        foreach(Transform child in transform){
            if(!child.gameObject.activeSelf) child.gameObject.SetActive(true);
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
