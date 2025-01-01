using TMPro;
using UnityEngine;

public abstract class BaseText : ButMonobehavior
{
    [SerializeField] protected TextMeshProUGUI pointText;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        if(pointText == null) pointText = GetComponent<TextMeshProUGUI>();
    }

    protected virtual void Update() {
        UpdateText();
    }

    protected abstract void UpdateText();
}