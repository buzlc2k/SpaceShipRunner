using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : Singleton<DifficultyManager>
{
    public GameSpeedDifficultyCtrl GameSpeedDifficultyCtrl;
    public BaseDifficulty ObstacleDifficultyCtrl;
    public CoinDifficultyCtrl CoinDifficultyCtrl;

    #region Property
    /// <summary>
    /// Tỉ lệ tốc độ hiện tại của trò chơi
    /// </summary>
    public float GameSpeedRate { get => GameSpeedDifficultyCtrl.GetGameSpeedRate(); }

    /// <summary>
    /// Tỉ lệ spawn ra coin
    /// </summary>
    public float CoinSpawnRate { get => CoinDifficultyCtrl.GetCoinSpawnData().Item1; }

    /// <summary>
    /// Tỉ lệ coin có thể spawn/ tổng số coin
    /// </summary>
    public float NumCoinSpawnedRate { get => CoinDifficultyCtrl.GetCoinSpawnData().Item2; }

    #endregion

    protected override void Reset()
    {
        base.Reset();

        if(GameSpeedDifficultyCtrl == null) GameSpeedDifficultyCtrl = GetComponentInChildren<GameSpeedDifficultyCtrl>();
        if(ObstacleDifficultyCtrl == null) ObstacleDifficultyCtrl = GetComponentInChildren<ObstacleDifficultyCtrl>();
        if(CoinDifficultyCtrl == null) CoinDifficultyCtrl = GetComponentInChildren<CoinDifficultyCtrl>();
    }
}