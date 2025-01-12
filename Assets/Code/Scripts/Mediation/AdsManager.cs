using UnityEngine;
using com.unity3d.mediation;
using System;
using TMPro;
using System.Collections.Generic;

public class AdsManager : Singleton<AdsManager>
{
    #if UNITY_ANDROID
        string appKey = "20ab36525";
    #else
        string appKey = "unexpected_platform";
    #endif

    [HideInInspector] public bool InternetReachable = true;
    
    protected override void Start() {
        if(Application.internetReachability.Equals(NetworkReachability.NotReachable))
            InternetReachable = false;
        else
            InitializeLevelPlaySDK();
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

    private void InitializeLevelPlaySDK(){
        IronSource.Agent.validateIntegration();
        LevelPlay.Init(appKey,adFormats:new []{LevelPlayAdFormat.REWARDED});
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