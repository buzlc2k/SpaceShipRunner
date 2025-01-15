using System.Collections;
using UnityEngine;

public class GameResultCD_CointCountText : BaseText
{
    protected override IEnumerator UpdateText()
    {
        yield return new WaitForSeconds(4.42f);

        float currentCoin = CoinTrackingManager.Instance.CurrentCoin;
        float targetTime = currentCoin * 1.1f;
        float time = 0;

        while (time <= targetTime) {
            time = Mathf.Clamp(time + Time.deltaTime * currentCoin, 0, currentCoin); 
            text.text = ((int)time).ToString();
            yield return null;
        }
    }
}