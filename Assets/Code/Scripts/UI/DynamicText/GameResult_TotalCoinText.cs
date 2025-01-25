using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult_TotalCoinText : GameResult_BaseAnimatedText
{
    protected Action<KeyValuePair<EventParameterType, object>> initializeAnimation;

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        initializeAnimation = (param) => {
            if(param.Value.Equals(PlacementID.DoubleCoinButton))
                StartCoroutine(InitializeAnimation(CoinTrackingManager.Instance.CurrentTotalCoin));
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
        yield return new WaitForSeconds(8.47f);

        yield return StartCoroutine(InitializeAnimation(CoinTrackingManager.Instance.CurrentTotalCoin));
    }

    protected override IEnumerator InitializeAnimation(float totalUnitCount, float animatedTime = 1.1f, float timeOffset = 0){
        yield return base.InitializeAnimation(totalUnitCount, animatedTime);

        ((GameResultCanvas)GetCanvas()).CoinVFX_CollectionPartical.PlayUIVFXPartical();
    }
}