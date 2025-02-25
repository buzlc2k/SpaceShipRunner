using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDifficultyCtrl : NonUpdatableDifficulty
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

    protected override bool CheckCanUpdateDifficulty()
    {
        return currentDifficultyLevel < coinSpawnerConfig.L_CoinSpawnOneTimeConfig.Count;
    }

    protected override IEnumerator InternalTimeBetweenUpdate()
    {
        yield return new WaitForSeconds(coinSpawnerConfig.TimeInterval);
    }

    protected override void UpdateGameDifficulty()
    {
        coinSpawnRate = coinSpawnerConfig.L_CoinSpawnOneTimeConfig[currentDifficultyLevel].CoinSpawnRates;
        numCoinSpawnedRate = coinSpawnerConfig.L_CoinSpawnOneTimeConfig[currentDifficultyLevel].NumCoinSpawnedRates;
        currentDifficultyLevel++;
    }
}