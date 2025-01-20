using System.Collections;
using UnityEngine;

public class GameResult_TotalCoinText : GameResult_BaseAnimatedText
{
    protected override IEnumerator UpdateText()
    {
        yield return new WaitForSeconds(8.47f);

        yield return StartCoroutine(InitializeAnimation(CoinTrackingManager.Instance.TotalCoin));
        
        ((GameResultCanvas)GetCanvas()).CoinVFX_CollectionPartical.PlayVFXPartical();
    }
}