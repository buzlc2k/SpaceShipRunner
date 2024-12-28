using TMPro;
using UnityEngine;

public class PointText : ButMonobehavior
{
    [SerializeField] TextMeshProUGUI pointText;

    private void Update() {
        UpdateText();
    }

    protected virtual void UpdateText(){
        pointText.text = ((int)PointTrackingManager.Instance.CurrentPoint).ToString();
    }
}