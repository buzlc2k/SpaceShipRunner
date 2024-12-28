using TMPro;
using UnityEngine;

public class PointText : BaseText
{
    protected override void UpdateText(){
        pointText.text = ((int)PointTrackingManager.Instance.CurrentPoint).ToString();
    }
}