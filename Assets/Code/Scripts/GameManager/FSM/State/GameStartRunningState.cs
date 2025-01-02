using System.Collections.Generic;
using UnityEngine;

public class GameStartRunningState : BaseGameState
{
    public GameStartRunningState(GameManager gameManager) : base(gameManager) { }

    public override void OnEnterState(){
        Debug.Log("StartScenceRunning");
        gameManager.CurrentGameState = GameState.StartSceneRunning;
    }
    public override void OnExitState(){
        
    }
}