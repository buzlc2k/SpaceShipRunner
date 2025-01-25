using System.Collections.Generic;
using UnityEngine;

public class ShoppingState : BaseGameState
{
    public ShoppingState(GameManager gameManager) : base(gameManager) { }

    public override void OnEnterState(){
        Debug.Log("Shopping");
        gameManager.CurrentGameState = GameState.Shopping;

        Observer.PostEvent(EventID.ChangeGameState, new KeyValuePair<EventParameterType, object>(EventParameterType.ChangeGameState_GameState, GameState.Shopping));
    }
    public override void OnExitState(){
        gameManager.PreviousGameState = GameState.Shopping;
    }
}