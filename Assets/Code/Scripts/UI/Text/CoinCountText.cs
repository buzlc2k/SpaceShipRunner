using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCountText : BaseText
{
    protected override void UpdateText(){
        pointText.text = "Coin: " + ((int)CoinTrackingManager.Instance.CurrentCoin).ToString();
    }
}