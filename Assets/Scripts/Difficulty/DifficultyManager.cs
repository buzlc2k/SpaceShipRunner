using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : Singleton<DifficultyManager>
{
    public BaseDifficultyAbstract GameSpeedDifficultyCtrl;
    public BaseDifficultyAbstract ObstacleDifficultyCtrl;
    public BaseDifficultyAbstract CoinDifficultyCtrl;

    private bool isCalculating = true; //Có đang tính toán không hay là đang reset rồi mới tính 

    #region Property
    /// <summary>
    /// Tỉ lệ tốc độ hiện tại của trò chơi
    /// </summary>
    public float GameSpeedRate { get => ((GameSpeedDifficultyCtrl)GameSpeedDifficultyCtrl).GetGameSpeedRate(); }

    /// <summary>
    /// Tỉ lệ spawn ra coin
    /// </summary>
    public float CoinSpawnRate { get => ((CoinDifficultyCtrl)CoinDifficultyCtrl).GetCoinSpawnData().Item1; }

    /// <summary>
    /// Tỉ lệ coin có thể spawn/ tổng số coin
    /// </summary>
    public float NumCoinSpawnedRate { get => ((CoinDifficultyCtrl)CoinDifficultyCtrl).GetCoinSpawnData().Item2; }

    #endregion

    protected override void OnEnable()
    {
        base.OnEnable();
        
        InitializeUpdateGameDifficulty();
    }

    protected override void Reset()
    {
        base.Reset();

        GameSpeedDifficultyCtrl = GetComponentInChildren<GameSpeedDifficultyCtrl>();
        ObstacleDifficultyCtrl = GetComponentInChildren<ObstacleDifficultyCtrl>();
        CoinDifficultyCtrl = GetComponentInChildren<CoinDifficultyCtrl>();
    }

    /// <summary>
    /// Tiến hành cập nhật độ khó của trò chơi
    /// </summary>
    /// <param name="resumePreviousState ">Có bắt đầu lại từ trạng thái trước đó không</param>
    public void InitializeUpdateGameDifficulty(bool resumePreviousState  = true)
    {
        if((isCalculating && resumePreviousState) || (!isCalculating && !resumePreviousState)){
            isCalculating = true;
            Observer.PostEvent(EventID.InitializeCalculateDifficulty, new KeyValuePair<EventParameterType, object>(EventParameterType.InitializeCalculateDifficulty_Null, null));
        }  
        else{
            isCalculating = false;
            Observer.PostEvent(EventID.InitializeResetUpdateCalculateDifficulty, new KeyValuePair<EventParameterType, object>(EventParameterType.InitializeResetUpdateCalculateDifficulty_Null, null));
        }    
    }

    /// <summary>
    /// Tạm dừng cập nhật độ khó của trò chơi
    /// </summary>
    public void PauseUpdateGameDifficulty()
    {
        Observer.PostEvent(EventID.PauseCalculateGameDifficulty, new KeyValuePair<EventParameterType, object>(EventParameterType.PauseCalculateGameDifficulty_Null, null));
    }
}