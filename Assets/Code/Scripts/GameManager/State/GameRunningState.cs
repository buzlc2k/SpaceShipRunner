using System.Collections.Generic;
using UnityEngine;

public class GameRunningState : BaseGameState
{
    public GameRunningState(GameManager gameManager) : base(gameManager) { }

    public override void OnEnterState(){
        Debug.Log("Run Game");
        gameManager.CurrentGameState = GameState.Running;
        gameManager.CurrentGameSession++;

        Observer.PostEvent(EventID.ChangeGameState, new KeyValuePair<EventParameterType, object>(EventParameterType.ChangeGameState_GameState, GameState.Running));
        Observer.PostEvent(EventID.EnterGameRunningState, new KeyValuePair<EventParameterType, object>(EventParameterType.EnterGameRunningState_Null, null));
    }
    public override void OnExitState(){
        gameManager.PreviousGameState = GameState.Running;
    }
}