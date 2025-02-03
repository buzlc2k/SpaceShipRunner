using System.Collections.Generic;
using UnityEngine;

public class EndGameState : BaseGameState
{
    public EndGameState(GameManager gameManager) : base(gameManager) { }

    public override void OnEnterState(){
        Debug.Log("Game End");
        gameManager.CurrentGameState = GameState.EndTransition;

        Observer.PostEvent(EventID.ChangeGameState, new KeyValuePair<EventParameterType, object>(EventParameterType.ChangeGameState_GameState, GameState.EndTransition));
        Observer.PostEvent(EventID.EnterEndTrasitionState, new KeyValuePair<EventParameterType, object>(EventParameterType.EnterEndTrasitionState_Null, null));

        gameManager.StartCoroutine(gameManager.ReloadGame());
    }
    public override void OnExitState(){
        gameManager.PreviousGameState = GameState.EndTransition;
    }
}