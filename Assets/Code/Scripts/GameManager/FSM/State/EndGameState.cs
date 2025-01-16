using System.Collections.Generic;
using UnityEngine;

public class EndGameState : BaseGameState
{
    public EndGameState(GameManager gameManager) : base(gameManager) { }

    public override void OnEnterState(){
        Debug.Log("Game End");
        gameManager.CurrentGameState = GameState.EndTransition;

        Observer.PostEvent(EventID.ChangeGameState, new KeyValuePair<EventParameterType, object>(EventParameterType.ChangeGameState_GameState, GameState.EndTransition));
    }
    public override void OnExitState(){
        gameManager.PreviousGameState = GameState.EndTransition;
    }
}