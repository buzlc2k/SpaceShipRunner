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
                yield return new WaitForSeconds(Time.deltaTime); 
                continue;
            }

            int currentDifficultyLevel = (int)(currentTime / obstacleTileSpawnerConfig.TimeInterval);

            if(currentDifficultyLevel < obstacleTileSpawnerConfig.ObstacleTilePrefabs.Count) 
                Observer.PostEvent(EventID.AddMoreObstacle, new KeyValuePair<EventParameterType, object>(EventParameterType.AddMoreObstacle_ListObstaclePrefab, obstacleTileSpawnerConfig.ObstacleTilePrefabs[currentDifficultyLevel].L_ObstacleTilePrefabs));

            yield return new WaitForSeconds(Time.deltaTime); 
        }

        yield break;
    }

    protected override IEnumerator C_ResetCalculateGameDifficulty()
    {
        //noop
        yield break;
    }

}