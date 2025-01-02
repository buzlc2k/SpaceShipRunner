using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class BaseButton : ButMonobehavior
{
    [SerializeField] private Button button;

    private UnityAction onButtonClickAction;

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

    private void AddButtonClickAction()
    {
        onButtonClickAction ??= () => {
            OnClick();
        };

        button.onClick.AddListener(onButtonClickAction);
    }

    protected abstract void OnClick();
}