using System.Collections;
using UnityEngine;

public class GameResultCD_CointCountText : GameResult_BaseAnimatedText
{
    protected override IEnumerator UpdateText()
    {
        yield return new WaitForSeconds(4.42f);

        yield return StartCoroutine(InitializeAnimation(CoinTrackingManager.Instance.CurrentCoinGained));
    }
}