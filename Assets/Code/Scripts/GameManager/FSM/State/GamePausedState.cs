using System.Collections.Generic;
using UnityEngine;

public class GamePausedState : BaseGameState
{
    public GamePausedState(GameManager gameManager) : base(gameManager) { }

    public override void OnEnterState(){
        Debug.Log("Pause game");
        gameManager.CurrentGameState = GameState.Paused;
    }
    public override void OnExitState(){

    }
}