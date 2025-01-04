using System.Collections.Generic;
using UnityEngine;

public class GameOverState : BaseGameState
{
    public GameOverState(GameManager gameManager) : base(gameManager) { }

    public override void OnEnterState(){
        Debug.Log("Game Over");
        gameManager.CurrentGameState = GameState.Over;

        Observer.PostEvent(EventID.ChangeGameState, new KeyValuePair<EventParameterType, object>(EventParameterType.ChangeGameState_GameState, GameState.Over));
    }
    public override void OnExitState(){

    }
}