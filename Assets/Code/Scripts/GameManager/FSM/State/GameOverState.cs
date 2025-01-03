using System.Collections.Generic;
using UnityEngine;

public class GameOverState : BaseGameState
{
    public GameOverState(GameManager gameManager) : base(gameManager) { }

    public override void OnEnterState(){
        Debug.Log("Game Over");
        gameManager.CurrentGameState = GameState.Over;
    }
    public override void OnExitState(){

    }
}