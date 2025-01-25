using System;
using System.Collections;

public class Shop_CoinCountText : BaseText
{
    protected override IEnumerator UpdateText()
    {
        while(true){
            if (!gameObject.activeInHierarchy)
            {
                yield break;
            }

            text.text = CoinTrackingManager.Instance.TotalCoins.ToString();
            yield return null;
        }
    }
}