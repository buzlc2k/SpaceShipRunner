using UnityEngine;
using com.unity3d.mediation;
using System;
using TMPro;
using System.Collections.Generic;

public class AdsManager : ButMonobehavior
{
    #if UNITY_ANDROID
        string appKey = "20ab36525";
    #else
        string appKey = "unexpected_platform";
    #endif
    
    protected override void Start() {
        IronSource.Agent.validateIntegration();
        LevelPlay.Init(appKey,adFormats:new []{LevelPlayAdFormat.REWARDED});
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        LevelPlay.OnInitSuccess += SdkInitializationCompletedEvent;
        LevelPlay.OnInitFailed += SdkInitializationFailedEvent;
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        LevelPlay.OnInitSuccess -= SdkInitializationCompletedEvent;
        LevelPlay.OnInitFailed -= SdkInitializationFailedEvent;
    }

    void OnApplicationPause(bool isPaused) { 	 
        IronSource.Agent.onApplicationPause(isPaused);	 
    }
    
    private void SdkInitializationCompletedEvent(LevelPlayConfiguration configuration)
    {
        Debug.Log("Init Success");
    }
    
    private void SdkInitializationFailedEvent(LevelPlayInitError error)
    {
        Debug.Log("Init Fail: "+ error.ToString());
    }

}