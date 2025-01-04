using System.Collections;
using TMPro;
using UnityEngine;

public class GameRunning_PointText : BaseText
{
    protected override void UpdateText()
    {
        text.text = ((int)PointTrackingManager.Instance.CurrentPoint).ToString();
    }
}