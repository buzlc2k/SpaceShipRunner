using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTrackingManager : Singleton<AudioTrackingManager>
{
    private bool currentAudioEnable;
    [SerializeField] AudioMixer audioMixer;
    private Action<KeyValuePair<EventParameterType, object>> switchEnableAudio;
    public bool CurrentAudioEnable { get => currentAudioEnable; }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        SetDefaultAudioEnable();
    }

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        switchEnableAudio = (param) => {
            SwitchEnableAudio();
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.ButtonMusic_Click, switchEnableAudio);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.ButtonMusic_Click, switchEnableAudio);
    }

    private void SetDefaultAudioEnable(){
        audioMixer.GetFloat("_Master", out float a);
        if(a == -80) currentAudioEnable = false;
        else currentAudioEnable = true;
    }

    private void SwitchEnableAudio(){
        currentAudioEnable = !currentAudioEnable;

        SetAudioMixerVolume();
    }

    private void SetAudioMixerVolume()
    {
        if(currentAudioEnable) audioMixer.SetFloat("_Master", 10);
        else audioMixer.SetFloat("_Master", -80);
    }
}