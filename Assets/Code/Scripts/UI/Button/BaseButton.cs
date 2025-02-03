using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;

public abstract class BaseButton : ButMonobehavior
{
    [SerializeField] protected Button button;

    protected UnityAction onButtonClickAction;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        if (button == null) button = GetComponent<Button>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        AddButtonClickAction();
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        button.onClick.RemoveListener(onButtonClickAction);
    }

    protected virtual BaseCanvas GetCanvas()
    {
        return GetComponentInParent<BaseCanvas>();
    }

    private void AddButtonClickAction()
    {
        onButtonClickAction ??= () => {
            Observer.PostEvent(EventID.BaseButton_Click, new KeyValuePair<EventParameterType, object>(EventParameterType.BaseButton_Click_Null, null));
            OnClick();
        };

        button.onClick.AddListener(onButtonClickAction);
    }

    protected abstract void OnClick();
}