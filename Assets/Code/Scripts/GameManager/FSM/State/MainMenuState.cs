using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : BaseGameState
{
    public MainMenuState(GameManager gameManager) : base(gameManager) { }

    public override void OnEnterState(){
        Debug.Log("StartScenceRunning");
        gameManager.CurrentGameState = GameState.MainMenu;

        Observer.PostEvent(EventID.ChangeGameState, new KeyValuePair<EventParameterType, object>(EventParameterType.ChangeGameState_GameState, GameState.MainMenu));
    }
    public override void OnExitState(){
        gameManager.PreviousGameState = GameState.MainMenu;
    }
}