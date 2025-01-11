using UnityEngine;
using com.unity3d.mediation;
using System;
using TMPro;
using System.Collections.Generic;

public class RewardedAds : ButMonobehavior
{
    private PlacementID currentPlacementID;
    private Action<KeyValuePair<EventParameterType, object>> showRewardAds; 

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        showRewardAds ??= (param) => {
            ShowRewardAds((PlacementID)param.Value);
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();
        //Add AdInfo Rewarded Video Events
        IronSourceRewardedVideoEvents.onAdOpenedEvent += RewardedVideoOnAdOpenedEvent;
        IronSourceRewardedVideoEvents.onAdClosedEvent += RewardedVideoOnAdClosedEvent;
        IronSourceRewardedVideoEvents.onAdAvailableEvent += RewardedVideoOnAdAvailable;
        IronSourceRewardedVideoEvents.onAdUnavailableEvent += RewardedVideoOnAdUnavailable;
        IronSourceRewardedVideoEvents.onAdShowFailedEvent += RewardedVideoOnAdShowFailedEvent;
        IronSourceRewardedVideoEvents.onAdRewardedEvent += RewardedVideoOnAdRewardedEvent;
        IronSourceRewardedVideoEvents.onAdClickedEvent += RewardedVideoOnAdClickedEvent;

        Observer.AddListener(EventID.ButtonRiveve_Click, showRewardAds);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();
        //Remove AdInfo Rewarded Video Events
        IronSourceRewardedVideoEvents.onAdOpenedEvent -= RewardedVideoOnAdOpenedEvent;
        IronSourceRewardedVideoEvents.onAdClosedEvent -= RewardedVideoOnAdClosedEvent;
        IronSourceRewardedVideoEvents.onAdAvailableEvent -= RewardedVideoOnAdAvailable;
        IronSourceRewardedVideoEvents.onAdUnavailableEvent -= RewardedVideoOnAdUnavailable;
        IronSourceRewardedVideoEvents.onAdShowFailedEvent -= RewardedVideoOnAdShowFailedEvent;
        IronSourceRewardedVideoEvents.onAdRewardedEvent -= RewardedVideoOnAdRewardedEvent;
        IronSourceRewardedVideoEvents.onAdClickedEvent -= RewardedVideoOnAdClickedEvent;

        Observer.RemoveListener(EventID.ButtonRiveve_Click, showRewardAds);
    }

    public void ShowRewardAds(PlacementID placementID){
        if(IronSource.Agent.isRewardedVideoAvailable()){
            currentPlacementID = placementID;
            IronSource.Agent.showRewardedVideo();
        }            
        else
            Debug.Log("No available reward");
    }

    /************* RewardedVideo AdInfo Delegates *************/
    // Indicates that there’s an available ad.
    // The adInfo object includes information about the ad that was loaded successfully
    // This replaces the RewardedVideoAvailabilityChangedEvent(true) event
    void RewardedVideoOnAdAvailable(IronSourceAdInfo adInfo) {
        Debug.Log("Rewarded Ads Availabled");
    }
    // Indicates that no ads are available to be displayed
    // This replaces the RewardedVideoAvailabilityChangedEvent(false) event
    void RewardedVideoOnAdUnavailable() {
        Debug.Log("Rewarded Ads Not Availabled");
    }
    // The Rewarded Video ad view has opened. Your activity will loose focus.
    void RewardedVideoOnAdOpenedEvent(IronSourceAdInfo adInfo){}
    // The Rewarded Video ad view is about to be closed. Your activity will regain its focus.
    void RewardedVideoOnAdClosedEvent(IronSourceAdInfo adInfo){}
    // The user completed to watch the video, and should be rewarded.
    // The placement parameter will include the reward data.
    // When using server-to-server callbacks, you may ignore this event and wait for the ironSource server callback.
    void RewardedVideoOnAdRewardedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo){
        Debug.Log("The player has watched all the ads");
        Observer.PostEvent(EventID.ADS_WatchFullAds, new KeyValuePair<EventParameterType, object>(EventParameterType.ADS_WatchFullAds_Placement, currentPlacementID));
    }
    // The rewarded video ad was failed to show.
    void RewardedVideoOnAdShowFailedEvent(IronSourceError error, IronSourceAdInfo adInfo){
        Debug.LogError("Can not show the ads: " + error.getDescription());
    }
    // Invoked when the video ad was clicked.
    // This callback is not supported by all networks, and we recommend using it only if
    // it’s supported by all networks you included in your build.
    void RewardedVideoOnAdClickedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo){
        Debug.Log("Player clicked to ads");
    }
}