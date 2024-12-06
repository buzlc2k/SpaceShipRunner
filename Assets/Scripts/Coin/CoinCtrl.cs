using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCtrl : ButMonobehavior, IPooled
{
    public Transform coinCube;
    public ObjMovement coinMovement;
    public ObjDespawn coinDespawn;
    public CoinConfig coinConfig;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        if(coinCube == null) coinCube = GetComponentInChildren<CoinCubeCtrl>().transform;
        if(coinMovement == null) coinMovement = GetComponentInChildren<ObjMovement>();
        if(coinDespawn == null) coinDespawn = GetComponentInChildren<ObjDespawn>();
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
