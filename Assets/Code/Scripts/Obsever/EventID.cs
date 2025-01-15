/// <summary>
/// Enumeration of possible EventIDs, defining types of events that can be triggered in the system.
/// </summary>
public enum EventID{
    None = 0,
    ResetWalkableTile,
    AddMoreObstacle,
    ObstacleTileSpawned,
    InitializeUpdatePhaseChanging,
    ChangePhase,
    B_Cube_Collide,
    W_Cube_Collide,
    Player_Collide,
    Player_TakeCoin,
    ButtonPauseGame_Click,
    ButtonResumeGameRunning_Click,
    ButtonResumeGameRestarting_Click,
    ChangeGameState,
    ADS_WatchFullAds,
    ButtonRiveve_Click,
    GameOver_FinishGameOver,
    FinishRestarting,
    ButtonPlayGame_Click,
}