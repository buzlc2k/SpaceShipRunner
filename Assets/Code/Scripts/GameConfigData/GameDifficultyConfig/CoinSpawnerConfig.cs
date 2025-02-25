using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/GameDifficultyConfig/CoinSpawnerConfig")]
public class CoinSpawnerConfig : ScriptableObject
{
    [Tooltip("Khoảng thời gian để cập nhật tỉ lệ spawn coin")] public float TimeInterval = 10f;

    public List<CoinSpawnOneTimeConfig> L_CoinSpawnOneTimeConfig;
}

[Serializable]
public class CoinSpawnOneTimeConfig{
    [Tooltip("Tỉ lệ spawn ra coin")] public float CoinSpawnRates;
    [Tooltip("Tỉ lệ số coin có thể spawn/ tổng số coin")] public float NumCoinSpawnedRates;
}