using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDifficultyCtrl : NonUpdatableDifficulty
{
    [Header("ObstacleDifficultyCtrl")]
    [SerializeField] private ObstacleTileSpawnerConfig obstacleTileSpawnerConfig;

    protected override bool CheckCanUpdateDifficulty()
    {
        return currentDifficultyLevel < obstacleTileSpawnerConfig.ObstacleTilePrefabs.Count;
    }

    protected override IEnumerator InternalTimeBetweenUpdate()
    {
        yield return new WaitForSeconds(obstacleTileSpawnerConfig.TimeInterval);
    }

    //Cập nhật các loại obstacle khác nhau dựa trên thời gian chơi
    protected override void UpdateGameDifficulty(){
        Observer.PostEvent(EventID.AddMoreObstacle, new KeyValuePair<EventParameterType, object>(EventParameterType.AddMoreObstacle_ListObstaclePrefab, obstacleTileSpawnerConfig.ObstacleTilePrefabs[currentDifficultyLevel].L_ObstacleTilePrefabs));
        currentDifficultyLevel++;
    }
}