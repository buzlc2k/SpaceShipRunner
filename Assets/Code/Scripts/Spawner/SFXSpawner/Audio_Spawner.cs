using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class Audio_Spawner : ButMonobehavior
{
    [Header("SFX_Spawner")]
    [SerializeField] protected GameObject Audio_Prefabs;
    [SerializeField] protected Transform Audio_Holder;
    protected ObjectPooler<BaseAudioCtrl> Audio_Poolers;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        Audio_Poolers = new ObjectPooler<BaseAudioCtrl>(Audio_Prefabs.GetComponent<BaseAudioCtrl>(), Audio_Holder, 1);
    }

    protected void SpawnAudio(){
        Audio_Poolers.Get(Vector3.zero, Quaternion.identity);
    }
}