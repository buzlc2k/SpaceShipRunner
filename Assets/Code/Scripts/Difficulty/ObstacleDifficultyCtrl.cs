using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDifficultyCtrl : BaseDifficulty
{
    [Header("ObstacleDifficultyCtrl")]
    [SerializeField] private ObstacleTileSpawnerConfig obstacleTileSpawnerConfig;

    //Cập nhật các loại obstacle khác nhau dựa trên thời gian chơi
    protected override void UpdatingGameDifficulty(){
        if(currentTime == 0) currentTime = 0.02f;
        else currentTime += Time.deltaTime; 
        
        if(currentTime % obstacleTileSpawnerConfig.TimeInterval > 0.02f) return;

        int currentDifficultyLevel = (int)(currentTime / obstacleTileSpawnerConfig.TimeInterval);

        if(currentDifficultyLevel < obstacleTileSpawnerConfig.ObstacleTilePrefabs.Count) 
            Observer.PostEvent(EventID.AddMoreObstacle, new KeyValuePair<EventParameterType, object>(EventParameterType.AddMoreObstacle_ListObstaclePrefab, obstacleTileSpawnerConfig.ObstacleTilePrefabs[currentDifficultyLevel].L_ObstacleTilePrefabs));
    }

    protected override void ResetingGameDifficulty()
    {
        
    }
}