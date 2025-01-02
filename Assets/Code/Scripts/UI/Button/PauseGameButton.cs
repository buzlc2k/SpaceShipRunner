using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PauseGameButton : BaseButton
{
    protected override void OnClick()
    {
        Observer.PostEvent(EventID.ButtonPauseGame_Click, new KeyValuePair<EventParameterType, object>(EventParameterType.ButtonPauseGame_Click_Null, null));
    }
}