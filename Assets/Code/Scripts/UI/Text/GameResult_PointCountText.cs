using System.Collections;
using UnityEngine;

public class GameResult_PointCountText : GameResult_BaseAnimatedText
{
    protected override IEnumerator UpdateText()
    {
        yield return new WaitForSeconds(6.12f);

        yield return StartCoroutine(InitializeAnimation(PointTrackingManager.Instance.CurrentPoint));
    }
}