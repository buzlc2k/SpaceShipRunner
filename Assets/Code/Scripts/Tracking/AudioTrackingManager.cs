using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTrackingManager : Singleton<AudioTrackingManager>
{
    private bool currentAudioEnable = true;
    [SerializeField] AudioMixer audioMixer;
    private Action<KeyValuePair<EventParameterType, object>> setEnableAudio;
    private Action<KeyValuePair<EventParameterType, object>> switchEnableAudio;
    public bool CurrentAudioEnable { get => currentAudioEnable; }

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        setEnableAudio = (param) => {
            SetEnableAudio((bool)param.Value);
        };

        switchEnableAudio = (param) => {
            SwitchEnableAudio();
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.LoadAudioEnableData, setEnableAudio);
        Observer.AddListener(EventID.ButtonMusic_Click, switchEnableAudio);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.LoadAudioEnableData, setEnableAudio);
        Observer.RemoveListener(EventID.ButtonMusic_Click, switchEnableAudio);
    }

    private void SetEnableAudio(bool currentAudioEnable){
        this.currentAudioEnable = currentAudioEnable;

        SetAudioMixerVolume();
    }

    private void SwitchEnableAudio(){
        currentAudioEnable = !currentAudioEnable;

        SetAudioMixerVolume();
    }

    private void SetAudioMixerVolume()
    {
        if(currentAudioEnable) audioMixer.SetFloat("_Master", 0);
        else audioMixer.SetFloat("_Master", -80);
    }
}