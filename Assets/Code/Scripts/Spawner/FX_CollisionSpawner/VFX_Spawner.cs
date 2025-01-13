using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class VFX_Spawner : ButMonobehavior
{
    [Header("VFX_Spawner")]
    [SerializeField] protected GameObject VFX_Prefabs;
    [SerializeField] protected Transform VFX_Holder;
    protected ObjectPooler<VFXCtrl> VFX_Poolers;
    protected Action<KeyValuePair<EventParameterType, object>> spawnVFX_Delegate;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        VFX_Poolers = new ObjectPooler<VFXCtrl>(VFX_Prefabs.GetComponent<VFXCtrl>(), VFX_Holder, 1);
    }
}