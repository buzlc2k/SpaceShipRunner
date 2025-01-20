using System.Collections;
using TMPro;
using UnityEngine;

public class GameRunning_PointText : BaseText
{
    protected override IEnumerator UpdateText()
    {
        while(true){
            if (!gameObject.activeInHierarchy)
            {
                yield break;
            }

            text.text = ((int)PointTrackingManager.Instance.CurrentPoint).ToString();
            yield return null;
        }
    }
}