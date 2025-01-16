using System.Collections.Generic;
using UnityEngine;

public class GameResultState : BaseGameState
{
    public GameResultState(GameManager gameManager) : base(gameManager) { }

    public override void OnEnterState(){
        Debug.Log("Game Result");
        gameManager.CurrentGameState = GameState.Result;

        Observer.PostEvent(EventID.ChangeGameState, new KeyValuePair<EventParameterType, object>(EventParameterType.ChangeGameState_GameState, GameState.Result));
        Observer.PostEvent(EventID.EnterGameResultState, new KeyValuePair<EventParameterType, object>(EventParameterType.EnterGameResultState_Null, null));
    }
    public override void OnExitState(){
        gameManager.PreviousGameState = GameState.Result;
    }
}