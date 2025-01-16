using System.Collections;
using UnityEngine;

public class GameResult_HeaderCoinCountText : GameResult_BaseAnimatedText
{
    protected override IEnumerator UpdateText()
    {
        yield return new WaitForSeconds(10.22f);

        yield return StartCoroutine(InitializeAnimation(CoinTrackingManager.Instance.TotalCoin, 1.25f));
    }
}