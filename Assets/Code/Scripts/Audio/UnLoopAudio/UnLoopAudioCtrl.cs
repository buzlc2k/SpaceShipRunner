using System;
using System.Collections.Generic;
using UnityEngine;

public class UnLoopAudioCtrl : BaseAudioCtrl
{
    public ObjDespawning UnLoopAudioDespawningByTime;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        if(UnLoopAudioDespawningByTime == null) UnLoopAudioDespawningByTime = GetComponentInChildren<ObjDespawning>();
    }
}