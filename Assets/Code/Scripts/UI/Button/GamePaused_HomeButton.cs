using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GamePaused_HomeButton : BaseButton
{
    protected override void OnClick()
    {
        Observer.PostEvent(EventID.ButtonHome_Click, new KeyValuePair<EventParameterType, object>(EventParameterType.ButtonHome_Click_Null, null));
    }
}