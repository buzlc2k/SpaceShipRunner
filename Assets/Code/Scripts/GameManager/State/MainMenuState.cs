using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : BaseGameState
{
    public MainMenuState(GameManager gameManager) : base(gameManager) { }

    public override void OnEnterState(){
        Debug.Log("Main Menu");
        gameManager.CurrentGameState = GameState.MainMenu;

        Observer.PostEvent(EventID.ChangeGameState, new KeyValuePair<EventParameterType, object>(EventParameterType.ChangeGameState_GameState, GameState.MainMenu));
        Observer.PostEvent(EventID.EnterMainMenuState, new KeyValuePair<EventParameterType, object>(EventParameterType.EnterMainMenuState_Null, null));
    }
    public override void OnExitState(){
        gameManager.PreviousGameState = GameState.MainMenu;
    }
}