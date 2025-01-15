using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDifficultyCtrl : BaseDifficulty
{
    [Header("CoinDifficultyCtrl")]
    [SerializeField] CoinSpawnerConfig coinSpawnerConfig;
    private float coinSpawnRate;
    private float numCoinSpawnedRate;

    protected override void LoadValue()
    {
        base.LoadValue();

        coinSpawnRate = 0;
        numCoinSpawnedRate = 0;
    }

    public Tuple<float, float> GetCoinSpawnData(){
        return Tuple.Create(coinSpawnRate, numCoinSpawnedRate);
    }

    protected override void UpdatingGameDifficulty()
    {
        if(currentTime == 0) currentTime = 0.02f;
        else currentTime += Time.deltaTime; 
            
        if(currentTime % coinSpawnerConfig.TimeInterval > 0.02f) return;

        int currentDifficultyLevel = (int)(currentTime / coinSpawnerConfig.TimeInterval);

        if(currentDifficultyLevel < coinSpawnerConfig.CoinSpawnRates.Count) 
            coinSpawnRate = coinSpawnerConfig.CoinSpawnRates[currentDifficultyLevel];
                
        if(currentDifficultyLevel < coinSpawnerConfig.NumCoinSpawnedRates.Count) 
            numCoinSpawnedRate = coinSpawnerConfig.NumCoinSpawnedRates[currentDifficultyLevel];
    }

    protected override void ResetingGameDifficulty()
    {
        
    }
}