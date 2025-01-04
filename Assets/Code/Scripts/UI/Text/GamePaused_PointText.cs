using System.Collections;
using TMPro;
using UnityEngine;

public class GamePaused_PointText : BaseText
{
    protected override void UpdateText()
    {
        text.text = "Point: " + ((int)PointTrackingManager.Instance.CurrentPoint).ToString();
    }
}