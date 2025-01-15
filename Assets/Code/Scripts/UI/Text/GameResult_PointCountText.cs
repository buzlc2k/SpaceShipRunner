using System.Collections;
using UnityEngine;

public class GameResult_PointCountText : BaseText
{
    protected override IEnumerator UpdateText()
    {
        yield return new WaitForSeconds(6.12f);

        float currentPoint = PointTrackingManager.Instance.CurrentPoint; 
        float targetTime = currentPoint * 1.1f;
        float time = 0;

        while (time < targetTime) {
            time = Mathf.Clamp(time + Time.deltaTime * currentPoint, 0, currentPoint); 
            text.text = ((int)time).ToString(); 
            yield return null;
        }
    }
}