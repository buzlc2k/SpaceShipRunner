using System;
using System.Collections;

public class GamePaused_CoinCountText : BaseText
{
    protected override IEnumerator UpdateText()
    {
        text.text = "Coin: " + ((int)CoinTrackingManager.Instance.CurrentCoin).ToString();
        yield return null;
    }
}