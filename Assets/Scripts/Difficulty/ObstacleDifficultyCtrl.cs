using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDifficultyCtrl : BaseDifficultyAbstract
{
    [Header("ObstacleDifficultyCtrl")]
    [SerializeField] private ObstacleTileSpawnerConfig obstacleTileSpawnerConfig;

    //Cập nhật các loại obstacle khác nhau dựa trên thời gian chơi
    protected override IEnumerator C_CalculateGameDifficulty(){
        while(CheckCanUpdateDifficulty()){

            currentTime += Time.deltaTime;
            
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

        yield break;
    }

    protected override IEnumerator C_ResetCalculateGameDifficulty()
    {
        //noop
        yield break;
    }

}