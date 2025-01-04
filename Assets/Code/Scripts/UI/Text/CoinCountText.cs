using System;
using System.Collections;

public class CoinCountText : BaseText
{
    protected override void UpdateText()
    {
        text.text = "Coin: " + ((int)CoinTrackingManager.Instance.CurrentCoin).ToString();
    }
}