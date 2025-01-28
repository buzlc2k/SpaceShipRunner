using System;
using System.Collections.Generic;
using UnityEngine;

public class AudiooManager : Singleton<AudiooManager>
{
    [SerializeField] protected AudioManagerConfig AudioManagerConfig;
    private List<ObjectPooler<BaseAudioCtrl>> audioPoolers = new();
    [SerializeField] private Transform audioHolder;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        foreach(var audioCtrl in AudioManagerConfig.AudioCtrls){
            var audioPooler = new ObjectPooler<BaseAudioCtrl>(audioCtrl, audioHolder, 1);
            audioPoolers.Add(audioPooler);
        }
    }

    public void PlayAudio(AudioID audioID){
        audioPoolers[AudioManagerConfig.AudioCtrls.FindIndex(ctrl => ctrl.AudioConfig.AudioID.Equals(audioID))].Get();
    }
}
