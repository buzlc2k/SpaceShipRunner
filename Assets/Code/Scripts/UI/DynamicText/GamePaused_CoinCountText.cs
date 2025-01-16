using System;
using System.Collections;

public class GamePaused_CoinCountText : BaseText
{
    protected override IEnumerator UpdateText()
    {
        text.text = "Coin: " + CoinTrackingManager.Instance.CurrentCoinGained.ToString();
        yield return null;
    }
}