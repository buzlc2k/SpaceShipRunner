using System.Collections.Generic;
using UnityEngine;

public class GameRestartingState : BaseGameState
{
    public GameRestartingState(GameManager gameManager) : base(gameManager) { }

    public override void OnEnterState(){
        Debug.Log("Restarting Game");
        gameManager.CurrentGameState = GameState.Restarting;

        Observer.PostEvent(EventID.ChangeGameState, new KeyValuePair<EventParameterType, object>(EventParameterType.ChangeGameState_GameState, GameState.Restarting));
    }
    
    public override void OnExitState(){
        gameManager.PreviousGameState = GameState.Restarting;
    }
}