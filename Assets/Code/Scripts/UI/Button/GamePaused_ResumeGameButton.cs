using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GamePaused_ResumeGameButton : BaseButton
{
    protected override void OnClick()
    {
        if(GameManager.Instance.PreviousGameState.Equals(GameState.Running))
            Observer.PostEvent(EventID.ButtonResumeGameRunning_Click, new KeyValuePair<EventParameterType, object>(EventParameterType.ButtonResumeGameRunning_Click_Null, null));
        else
            Observer.PostEvent(EventID.ButtonResumeGameRestarting_Click, new KeyValuePair<EventParameterType, object>(EventParameterType.ButtonResumeGameRestarting_Click_Null, null));
    }
}