using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOver_ContinueButton : BaseButton
{
    protected override void OnClick()
    {
        Observer.PostEvent(EventID.GameOver_FinishGameOver, new KeyValuePair<EventParameterType, object>(EventParameterType.GameOver_FinishGameOver_Null, null));
    }
}