using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResumeGameButton : BaseButton
{
    protected override void OnClick()
    {
        Observer.PostEvent(EventID.ButtonResumeGame_Click, new KeyValuePair<EventParameterType, object>(EventParameterType.ButtonResumeGame_Click_Null, null));
    }
}