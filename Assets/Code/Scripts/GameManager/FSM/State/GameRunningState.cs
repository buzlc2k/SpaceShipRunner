using System.Collections.Generic;
using UnityEngine;

public class GameRunningState : BaseGameState
{
    public GameRunningState(GameManager gameManager) : base(gameManager) { }

    public override void OnEnterState(){
        Debug.Log("Run Game");
        gameManager.InitializeUpdateGame();
    }
    public override void OnExitState(){

    }
}