using System.Collections.Generic;
using UnityEngine;

public enum GameState{
    None = 0,
    StartTransition,
    MainMenu,
    Running,
    Paused,
    Restarting,
    Over,
    Result,
    EndTransition,
}

public class GameManager : Singleton<GameManager>
{
    private StateMachine gameStateMachine;
    [HideInInspector] public GameState PreviousGameState;
    [HideInInspector] public GameState CurrentGameState;
    [HideInInspector] public int CurrentGameSession = 0;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        //Load State Machine
        gameStateMachine = new StateMachine();
    }

    protected override void Start()
    {
        base.Start();

        //load State
        var startGameState = new StartGameState(this);
        var mainMenuSatate = new MainMenuState(this);
        var gameRunningState = new GameRunningState(this);
        var gamePausedState = new GamePausedState(this);
        var gameOverState = new GameOverState(this);
        var gameRestartingState = new GameRestartingState(this);  
        var gameResultState = new GameResultState(this);  
        var EndGameState = new EndGameState(this);    

        //Define transition
        gameStateMachine.AddTransition(startGameState, mainMenuSatate, new TimerPredicate(1.5f));

        gameStateMachine.AddTransition(mainMenuSatate, gameRunningState, new EventPredicate(EventID.ButtonPlayGame_Click));

        gameStateMachine.AddTransition(gameRunningState, gamePausedState, new EventPredicate(EventID.ButtonPauseGame_Click));
        gameStateMachine.AddTransition(gamePausedState, gameRunningState, new EventPredicate(EventID.ButtonResumeGameRunning_Click));
        gameStateMachine.AddTransition(gameRunningState, gameOverState, new EventPredicate(EventID.Player_Collide));

        gameStateMachine.AddTransition(gameOverState, gameRestartingState, new EventPredicate(EventID.ADS_WatchFullAds, PlacementID.ReviveButton));
        gameStateMachine.AddTransition(gameRestartingState, gameRunningState, new EventPredicate(EventID.FinishRestarting));
        gameStateMachine.AddTransition(gameRestartingState, gamePausedState, new EventPredicate(EventID.ButtonPauseGame_Click));
        gameStateMachine.AddTransition(gamePausedState, gameRestartingState, new EventPredicate(EventID.ButtonResumeGameRestarting_Click));

        gameStateMachine.AddTransition(gameOverState, gameResultState, new EventPredicate(EventID.GameOver_FinishGameOver));

        gameStateMachine.AddTransition(gameResultState, EndGameState, new EventPredicate(EventID.ButtonEndGame_Click));
        //End

        //Set default state
        gameStateMachine.SetState(startGameState);
    }

    private void Update() {
        gameStateMachine.StateMachineUpdate();
    }
}