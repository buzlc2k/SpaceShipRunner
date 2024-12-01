using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/GameSpeedRateConfig")]
public class GameSpeedRateConfig : ScriptableObject
{
    [Tooltip("Thời gian tối thiểu người chơi có thể phản ứng với chướng ngại vật.")] 
    public float MinObstacleTimeToReact = 2f;

    [Tooltip("Thời gian tối đa người chơi có thể phản ứng với chướng ngại vật.")] 
    public float MaxObstacleTimeToReact = 6f;

    [Tooltip("Thời gian người chơi có thể phản ứng với chướng ngại vật bị giảm sau 1 giây.")] 
    public float ObstacleTimeToReactReducePerSecond = 0.1f;

    [Tooltip("Chu kỳ tăng bất ngờ thời gian phản ứng.")] 
    public float SurpriseTimeInterval = 15f;

    [Tooltip("Thời gian thêm vào khi đạt chu kỳ bất ngờ.")] 
    public float SurpriseTimeToRectBonus = 0.5f;
}
