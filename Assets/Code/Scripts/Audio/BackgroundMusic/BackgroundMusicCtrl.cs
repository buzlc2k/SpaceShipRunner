using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System;

public class BackgroundMusicCtrl : BaseAudioCtrl
{
    protected Action<KeyValuePair<EventParameterType, object>> fadeIn_Delegate;
    protected Action<KeyValuePair<EventParameterType, object>> fadeOut_Delegate;
    protected Action<KeyValuePair<EventParameterType, object>> fadeLouder_Delegate;
    protected Action<KeyValuePair<EventParameterType, object>> fadeSmaller_Delegate;

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        fadeIn_Delegate ??= (param) => {
            Fade(1.5f, 0.05f);
        };

        fadeOut_Delegate ??= (param) => {
            Fade(1.5f, 0f);
        };

        fadeLouder_Delegate ??= (param) => {
            Fade(1.5f, 0.15f);
        };

        fadeSmaller_Delegate ??= (param) => {
            Fade(1.5f, 0.05f);
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.EnterGameRunningState, fadeLouder_Delegate);
        Observer.AddListener(EventID.EnterGameRestartingState, fadeLouder_Delegate);
        Observer.AddListener(EventID.EnterGameOverState, fadeSmaller_Delegate);
        Observer.AddListener(EventID.EnterStartTrasitionState, fadeIn_Delegate);
        Observer.AddListener(EventID.EnterEndTrasitionState, fadeOut_Delegate);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.EnterGameRunningState, fadeLouder_Delegate);
        Observer.RemoveListener(EventID.EnterGameRestartingState, fadeLouder_Delegate);
        Observer.RemoveListener(EventID.EnterGameOverState, fadeSmaller_Delegate);
        Observer.RemoveListener(EventID.EnterStartTrasitionState, fadeIn_Delegate);
        Observer.RemoveListener(EventID.EnterEndTrasitionState, fadeOut_Delegate);
    }

    public void Fade(float timeFade, float targetVolume){
        StartCoroutine(FadeAudio(timeFade, targetVolume));
    }

    protected virtual IEnumerator FadeAudio(float timeFade, float targetVolume){
        float timer = timeFade;
        float volumeRange = AudioSource.volume - targetVolume;

        while(timer > 0){
            timer -= Time.deltaTime;
            AudioSource.volume = targetVolume + (timer/timeFade) * volumeRange;
            yield return null;
        }
    }
}