using System;
using UnityEngine;

public abstract class BaseAudioCtrl : ButMonobehavior, IPooled
{
    [HideInInspector] public AudioClip CurrentAudioClip;
    public AudioSource AudioSource;
    public AudioConfig AudioConfig;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        if(AudioSource == null) AudioSource = GetComponent<AudioSource>();
        if(AudioConfig.AudioClips.Count == 1) CurrentAudioClip = AudioConfig.AudioClips[0];
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        Play();
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        ReleaseCallback?.Invoke(gameObject);
    }

    public virtual void Play()
	{
        AudioSource.clip = GetRandomAudioClip();
        AudioSource.pitch = GetRandomAudioPitch();
		AudioSource.Play();

        if(CurrentAudioClip !=  AudioSource.clip) CurrentAudioClip = AudioSource.clip;
	}

    public AudioClip GetRandomAudioClip(){
        return AudioConfig.AudioClips[UnityEngine.Random.Range(0, AudioConfig.AudioClips.Count)];
    }

    public float GetRandomAudioPitch(){
        return UnityEngine.Random.Range(AudioConfig.LowPitchRange, AudioConfig.HighPitchRange);
    }

    public Action<GameObject> ReleaseCallback { get; set; }
}