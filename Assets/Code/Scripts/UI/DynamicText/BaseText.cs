using System.Collections;
using TMPro;
using UnityEngine;

public abstract class BaseText : ButMonobehavior
{
    [SerializeField] protected TextMeshProUGUI text;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        if(text == null) text = GetComponent<TextMeshProUGUI>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        StartCoroutine(UpdateText());
    }

    protected virtual BaseCanvas GetCanvas()
    {
        return GetComponentInParent<BaseCanvas>();
    }

    protected abstract IEnumerator UpdateText();
}