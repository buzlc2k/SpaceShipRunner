/// <summary>
/// Defines types of parameters that can be sent within a triggered event.
/// Enum constants follow the format 'EventID_KeyName' for clarity.
/// </summary>
public enum EventParameterType{
    None = 0,
    ResetWalkableTile_WalkableTileObject,
    AddMoreObstacle_ListObstaclePrefab,
    ObstacleTileSpawned_WalkableTileObjectAndListSpawnPositions,
    InitializeUpdatePhaseChanging_TupleColor,
    ChangePhase_Null,
    B_Cube_Collide_CubeObject,
    W_Cube_Collide_CubeObject,
    Player_Collide_PlayerObject,
    Player_TakeCoin_Null,
    ButtonPauseGame_Click_Null,
    ButtonResumeGameRunning_Click_Null,
    ButtonResumeGameRestarting_Click_Null,
    ChangeGameState_GameState,
    EnterMainMenuState_Null,
    EnterGameRunningState_Null,
    EnterGamePausedState_Null,
    EnterGameOverState_Null,
    EnterGameRestartingState_Null,
    EnterGameResultState_Null,
    ADS_WatchFullAds_Placement,
    ButtonRiveve_Click_Placement,
    ButtonDoubleCoin_Click_Placement,
    GameOver_FinishGameOver_Null,
    FinishRestarting_Null,
    ButtonPlayGame_Click_Null,
    ButtonReloadGame_Click_Null,
    LoadCoinsData_TotalCoins,
    LoadCurrentSpaceShipData_CurrentSpaceShip,
    LoadSpaceShipOwnedData_SpaceShipOwned,
    SetCurrentSpaceShipSuccess_Null,






    //Test
    SpaceShipItem_SelectedItem_SpaceShipConfig,
    SpaceShipItem_OwnedItemClick_SpaceShipConfig,
    WantToBuyItem_ItemConfig,
    SpaceShipItem_BuySuccess_SpaceShipConfig,
    MinusTotalCoin_Coins,
    ButtonShopping_Click_Null,
    ButtonHome_Click_Null,
    CoinItem_BuySuccess_CoinConfigID,
}