using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult_HeaderCoinCountText : GameResult_BaseAnimatedText
{
    protected Action<KeyValuePair<EventParameterType, object>> initializeAnimation;

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        initializeAnimation = (param) => {
            if(param.Value.Equals(PlacementID.DoubleCoinButton))
                StartCoroutine(InitializeAnimation(CoinTrackingManager.Instance.CurrentTotalCoin, 1.25f, 1.12f));
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.ADS_WatchFullAds, initializeAnimation);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.ADS_WatchFullAds, initializeAnimation);
    }


    protected override IEnumerator UpdateText()
    {
        yield return new WaitForSeconds(10.22f);

        yield return StartCoroutine(InitializeAnimation(CoinTrackingManager.Instance.CurrentTotalCoin, 1.25f));
    }
}