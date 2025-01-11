using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOver_ReviveButton : BaseButton
{
    protected override void OnClick()
    {
        Observer.PostEvent(EventID.ButtonRiveve_Click, new KeyValuePair<EventParameterType, object>(EventParameterType.ButtonRiveve_Click_Placement, PlacementID.ReviveButton));
    }
}