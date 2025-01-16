using System.Collections.Generic;
using UnityEngine;

public class StartGameState : BaseGameState
{
    public StartGameState(GameManager gameManager) : base(gameManager) { }

    public override void OnEnterState(){
        Debug.Log("Game Start");
        gameManager.CurrentGameState = GameState.StartTransition;

        Observer.PostEvent(EventID.ChangeGameState, new KeyValuePair<EventParameterType, object>(EventParameterType.ChangeGameState_GameState, GameState.StartTransition));
    }
    public override void OnExitState(){
        gameManager.PreviousGameState = GameState.StartTransition;
    }
}