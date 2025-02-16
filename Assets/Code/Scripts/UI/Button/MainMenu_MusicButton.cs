using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenu_MusicButton : BaseButton
{
    [SerializeField] Material musicEnabledMaterial;
    [SerializeField] Material musicUnEnabledMaterial;

    protected override void Start()
    {
        base.Start();

        SetButtonMaterial();
    }

    private void SetButtonMaterial()
    {
        if(AudioTrackingManager.Instance.CurrentAudioEnable) GetComponent<Image>().material = musicEnabledMaterial;
        else GetComponent<Image>().material = musicUnEnabledMaterial;
    }

    protected override void OnClick()
    {
        Observer.PostEvent(EventID.ButtonMusic_Click, new KeyValuePair<EventParameterType, object>(EventParameterType.ButtonMusic_Click_Null, null));
        SetButtonMaterial();
    }
}