using System;
using System.Collections;

public class GameRunning_CoinCountText : BaseText
{
    protected override IEnumerator UpdateText()
    {
        while (true){
            if (!gameObject.activeInHierarchy)
            {
                yield break;
            }

            text.text = "Coin: " + ((int)CoinTrackingManager.Instance.CurrentCoin).ToString();
            yield return null;
        }
    }
}