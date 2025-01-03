using System.Collections.Generic;
using UnityEngine;

public enum GameState{
    None = 0,
    StartSceneRunning,
    Running,
    Paused,
    Restarting,
    Over,
}

public class GameManager : Singleton<GameManager>
{
    private StateMachine gameStateMachine;
    public GameState CurrentGameState;

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
        var gameRunningState = new GameRunningState(this);
        var gamePausedState = new GamePausedState(this);
        var gameOverState = new GameOverState(this);

        //Define transition
        gameStateMachine.AddTransition(gameRunningState, gamePausedState, new EventPredicate(EventID.ButtonPauseGame_Click));
        gameStateMachine.AddTransition(gamePausedState, gameRunningState, new EventPredicate(EventID.ButtonResumeGame_Click));
        gameStateMachine.AddTransition(gameRunningState, gameOverState, new EventPredicate(EventID.Player_Collide));

        //Set default state
        gameStateMachine.SetState(gameRunningState);
    }

    private void Update() {
        gameStateMachine.StateMachineUpdate();
    }
}