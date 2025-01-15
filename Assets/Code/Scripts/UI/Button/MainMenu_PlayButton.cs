using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenu_PlayButton : BaseButton
{
    protected override void OnClick()
    {
        Observer.PostEvent(EventID.ButtonPlayGame_Click, new KeyValuePair<EventParameterType, object>(EventParameterType.ButtonPlayGame_Click_Null, null));
    }
}