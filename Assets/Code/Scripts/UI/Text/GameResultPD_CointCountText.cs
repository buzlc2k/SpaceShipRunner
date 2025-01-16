using System.Collections;
using UnityEngine;

public class GameResultPD_CointCountText : GameResult_BaseAnimatedText
{
    protected override IEnumerator UpdateText()
    {
        yield return new WaitForSeconds(7.22f);

        yield return StartCoroutine(InitializeAnimation(CoinTrackingManager.Instance.CurrentPointCoin));
    }
}