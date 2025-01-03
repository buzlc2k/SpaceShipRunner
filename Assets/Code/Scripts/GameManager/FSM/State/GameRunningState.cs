using System.Collections.Generic;
using UnityEngine;

public class GameRunningState : BaseGameState
{
    public GameRunningState(GameManager gameManager) : base(gameManager) { }

    public override void OnEnterState(){
        Debug.Log("Run Game");
        gameManager.CurrentGameState = GameState.Running;

        Observer.PostEvent(EventID.ChangeGameState, new KeyValuePair<EventParameterType, object>(EventParameterType.ChangeGameState_GameState, GameState.Running));
    }
    public override void OnExitState(){

    }
}