using System.Collections.Generic;
using UnityEngine;

public class GamePausedState : BaseGameState
{
    public GamePausedState(GameManager gameManager) : base(gameManager) { }

    public override void OnEnterState(){
        Debug.Log("Pause game");
    }
    public override void OnExitState(){

    }
}