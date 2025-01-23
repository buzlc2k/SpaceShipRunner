using System.Collections.Generic;
using UnityEngine;

public class GamePausedState : BaseGameState
{
    public GamePausedState(GameManager gameManager) : base(gameManager) { }

    public override void OnEnterState(){
        Debug.Log("Pause game");
        gameManager.CurrentGameState = GameState.Paused;
        Time.timeScale = 0;

        Observer.PostEvent(EventID.ChangeGameState, new KeyValuePair<EventParameterType, object>(EventParameterType.ChangeGameState_GameState, GameState.Paused));
        Observer.PostEvent(EventID.EnterGamePausedState, new KeyValuePair<EventParameterType, object>(EventParameterType.EnterGamePausedState_Null, null));
    }
    public override void OnExitState(){
        Time.timeScale = 1;
        gameManager.PreviousGameState = GameState.Paused;
    }
}