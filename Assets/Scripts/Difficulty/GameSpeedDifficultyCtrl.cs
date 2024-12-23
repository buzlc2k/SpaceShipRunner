using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedDifficultyCtrl : BaseDifficultyAbstract
{
    [Header("GameSpeedDifficultyCtrl")]
    [SerializeField] private GameSpeedRateConfig gameSpeedRateConfig;
    private GameSpeedRateCalculator gameSpeedRateCalculator;
    private float gameSpeedRate;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        gameSpeedRateCalculator = new GameSpeedRateCalculator(gameSpeedRateConfig);
    }

    protected override void LoadValue()
    {
        base.LoadValue();

        maxTimeToCalculate = gameSpeedRateCalculator.GetMaxTimeToCalculate();

        gameSpeedRate = 0f;
    }

    public float GetGameSpeedRate(){
        return gameSpeedRate;
    }

    // Cập nhật tốc độ trò chơi dựa trên thời gian
    protected override IEnumerator C_CalculateGameDifficulty()
    {
        while (CheckCanUpdateDifficulty())
        {
            this.currentTime += Time.deltaTime;
            this.gameSpeedRate = gameSpeedRateCalculator.GetGameSpeedRate(currentTime);
            yield return null;
        }

        yield break;
    }

    // Đặt lại thời gian rồi bắt đầu lại
    protected override IEnumerator C_ResetCalculateGameDifficulty()
    {
        while (CheckCanResetUpdateDifficulty())
        {
            this.currentTime = Mathf.Clamp(currentTime - 10 * Time.deltaTime, 0, currentTime); // Giảm thời gian nhanh hơn để reset
            this.gameSpeedRate = gameSpeedRateCalculator.GetGameSpeedRate(currentTime);
            yield return null;
        }

        StartCoroutine(C_CalculateGameDifficulty());
        yield break;
    }
}

internal class GameSpeedRateCalculator
{
    private readonly GameSpeedRateConfig config;

    internal GameSpeedRateCalculator(GameSpeedRateConfig config)
    {
        this.config = config;
    }

    /// <summary>
    /// Tính tốc độ tỷ lệ của trò chơi dựa trên thời gian đã qua.
    /// </summary>
    /// <param name="_time">Thời gian đã qua (theo giây).</param>
    /// <returns>Giá trị tỷ lệ tốc độ trò chơi.</returns>
    internal float GetGameSpeedRate(float elapsedTime)
    {
        //Tính thời gian hiện tại để người chơi có thể phản ứng với chướng ngại vật
        //Cứ 15s lại tăng cho người chơi 0.5s để giảm độ khó của game và tạo bất ngờ
        //_time càng lơn thì thời gian để người chơi có thể phản ứng với chướng ngại vật càng giảm đi -> tăng độ khó cho game
        float currentReactionTime = Math.Max(
            config.MinObstacleTimeToReact,
            config.MaxObstacleTimeToReact 
            - config.ObstacleTimeToReactReducePerSecond * elapsedTime 
            + config.SurpriseTimeToRectBonus * (int)(elapsedTime / config.SurpriseTimeInterval)
        );
        //Vận tốc của Obstacle hiện tại
        float currentObstacleSpeed = 1 / currentReactionTime;
        //Độ chênh lệch vận tốc của Obstacle hiện tại
        float defaultObstacleSpeed = 1 / config.MaxObstacleTimeToReact;
        //Vận tốc Obstacle ban đầu
        float initialObstacleSpeed = 1 / config.MaxObstacleTimeToReact;

        // Cho ra tốc độ tỉ lệ của trò chơi
        return (currentObstacleSpeed - defaultObstacleSpeed) / initialObstacleSpeed;
    }

    /// <summary>
    /// Lấy quãng thời gian lớn nhất để có thể rate tỷ lệ tốc độ trò chơi, có thể chênh so với kết quả <= 10s
    /// </summary>
    internal int GetMaxTimeToCalculate()
    {
        //Tính dựa trên phương trình
        // SurpriseTimeInterval * MinObstacleTimeToRect 
        // = SurpriseTimeInterval * MaxObstacleTimeToRect - SurpriseTimeInterval * ObstacleTimeToRectReducePerSecond * x + SurpriseTimeToRectBonus * (int)x;
        float x1 = config.SurpriseTimeInterval * (config.MaxObstacleTimeToReact - config.MinObstacleTimeToReact);
        float x2 = config.SurpriseTimeInterval * config.ObstacleTimeToReactReducePerSecond - config.SurpriseTimeToRectBonus;
        return (int)(x1 / x2);
    }
}