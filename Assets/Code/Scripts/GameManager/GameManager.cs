using System.Collections.Generic;
using UnityEngine;

public enum GameState{
    None = 0,
    MainMenu,
    Running,
    Paused,
    Restarting,
    Over,
}

public class GameManager : Singleton<GameManager>
{
    private StateMachine gameStateMachine;
    [HideInInspector] public GameState PreviousGameState;
    [HideInInspector] public GameState CurrentGameState;
    [HideInInspector] public int CurrentGameSession = 0;

    protected override void Awake()
    {
        base.Awake();

        //Load State Machine
        gameStateMachine = new StateMachine();
    }

    protected override void Start()
    {
        base.Start();

        //load State
        var mainMenuSatate = new MainMenuState(this);
        var gameRunningState = new GameRunningState(this);
        var gamePausedState = new GamePausedState(this);
        var gameOverState = new GameOverState(this);
        var gameRestartingState = new GameRestartingState(this);        

        //Define transition
        gameStateMachine.AddTransition(mainMenuSatate, gameRunningState, new EventPredicate(EventID.ButtonPlayGame_Click));

        gameStateMachine.AddTransition(gameRunningState, gamePausedState, new EventPredicate(EventID.ButtonPauseGame_Click));
        gameStateMachine.AddTransition(gamePausedState, gameRunningState, new EventPredicate(EventID.ButtonResumeGameRunning_Click));
        gameStateMachine.AddTransition(gameRunningState, gameOverState, new EventPredicate(EventID.Player_Collide));

        gameStateMachine.AddTransition(gameOverState, gameRestartingState, new EventPredicate(EventID.ADS_WatchFullAds, PlacementID.ReviveButton));
        gameStateMachine.AddTransition(gameRestartingState, gameRunningState, new EventPredicate(EventID.FinishRestarting));
        gameStateMachine.AddTransition(gameRestartingState, gamePausedState, new EventPredicate(EventID.ButtonPauseGame_Click));
        gameStateMachine.AddTransition(gamePausedState, gameRestartingState, new EventPredicate(EventID.ButtonResumeGameRestarting_Click));

        //Set default state
        gameStateMachine.SetState(mainMenuSatate);
    }

    private void Update() {
        gameStateMachine.StateMachineUpdate();
    }
}