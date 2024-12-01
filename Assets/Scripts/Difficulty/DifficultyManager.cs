using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : Singleton<DifficultyManager>
{
    private float currentTime;
    private float maxTimeToRate;
    private bool isRating;

    protected override void Awake()
    {
        base.Awake();
        gameSpeedRateCalculator = new GameSpeedRateCalculator(gameSpeedRateConfig);
    }

    protected override void Start() {
        base.Start();
        InitializeUpdateGameDifficulty();
    }

    protected override void LoadValue()
    {
        base.LoadValue();

        isRating = false;
        currentTime = 0f;
        maxTimeToRate = gameSpeedRateCalculator.GetMaxTimeToRate();

        gameSpeedRate = 0f;
    }

    /// <summary>
    /// Tiến hành cập nhật độ khó của trò chơi
    /// </summary>
    /// <param name="resumePreviousState">Tiếp tục tính toán độ khó từ trạng thái hiện tại</param>
    public void InitializeUpdateGameDifficulty(bool resumePreviousState = true)
    {
        isRating = true;

        if (resumePreviousState) {
            StartCoroutine(UpdateGameSpeedRate());
            StartCoroutine(UpdateObstacleTileSpawner());
        }

        else StartCoroutine(ResetAndStartRateGameSpeed());
    }

    /// <summary>
    /// Tạm dừng cập nhật độ khó của trò chơi
    /// </summary>
    public void PauseUpdateGameDifficulty()
    {
        isRating = false;
    }

    #region GameSpeedRate

    [Header("GameSpeedRate")]
    [SerializeField] private GameSpeedRateConfig gameSpeedRateConfig;
    private GameSpeedRateCalculator gameSpeedRateCalculator;
    private float gameSpeedRate;

    /// <summary>
    /// Tỉ lệ tốc độ hiện tại của trò chơi
    /// </summary>
    public float GameSpeedRate => gameSpeedRate;

    // Cập nhật tốc độ trò chơi dựa trên thời gian
    private IEnumerator UpdateGameSpeedRate()
    {
        while (isRating && currentTime <= maxTimeToRate)
        {
            currentTime += Time.deltaTime;
            gameSpeedRate = gameSpeedRateCalculator.CalculateGameSpeedRate(currentTime);
            yield return null;
        }
    }

    // Đặt lại thời gian rồi bắt đầu lại
    private IEnumerator ResetAndStartRateGameSpeed()
    {
        while (isRating && currentTime > 0)
        {
            currentTime = Mathf.Clamp(currentTime - 10 * Time.deltaTime, 0, currentTime); // Giảm thời gian nhanh hơn để reset
            gameSpeedRate = gameSpeedRateCalculator.CalculateGameSpeedRate(currentTime);
            yield return null;
        }

        StartCoroutine(UpdateGameSpeedRate());
    }

    #endregion

    #region UpdateObstacleTileSpawner

    [SerializeField] private ObstacleTileSpawnerConfig obstacleTileSpawnerConfig;

    // Kiểm tra thông báo update obstacle tới ObstacleTileSpawner
    private IEnumerator UpdateObstacleTileSpawner(){
        while(isRating && currentTime <= maxTimeToRate){

            if(currentTime % obstacleTileSpawnerConfig.TimeInterval > 0.02f){
                yield return null;
                continue;
            }

            switch((int)(currentTime / obstacleTileSpawnerConfig.TimeInterval)){
                case 0:
                    Observer.PostEvent(EventID.AddMoreObstacle, new KeyValuePair<EventParameterType, object>(EventParameterType.AddMoreObstacle_ListObstaclePrefab, obstacleTileSpawnerConfig.ObstacleTilePrefabs_1));
                    break;
                case 1: 
                    Observer.PostEvent(EventID.AddMoreObstacle, new KeyValuePair<EventParameterType, object>(EventParameterType.AddMoreObstacle_ListObstaclePrefab, obstacleTileSpawnerConfig.ObstacleTilePrefabs_2));
                    break;
                case 2: 
                    Observer.PostEvent(EventID.AddMoreObstacle, new KeyValuePair<EventParameterType, object>(EventParameterType.AddMoreObstacle_ListObstaclePrefab, obstacleTileSpawnerConfig.ObstacleTilePrefabs_3));
                    break;
            }

            yield return null;
        }
        
    }

    #endregion
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
    internal float CalculateGameSpeedRate(float elapsedTime)
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
    internal int GetMaxTimeToRate()
    {
        //Tính dựa trên phương trình
        // SurpriseTimeInterval * MinObstacleTimeToRect 
        // = SurpriseTimeInterval * MaxObstacleTimeToRect - SurpriseTimeInterval * ObstacleTimeToRectReducePerSecond * x + SurpriseTimeToRectBonus * (int)x;
        float x1 = config.SurpriseTimeInterval * (config.MaxObstacleTimeToReact - config.MinObstacleTimeToReact);
        float x2 = config.SurpriseTimeInterval * config.ObstacleTimeToReactReducePerSecond - config.SurpriseTimeToRectBonus;
        return (int)(x1 / x2);
    }
}