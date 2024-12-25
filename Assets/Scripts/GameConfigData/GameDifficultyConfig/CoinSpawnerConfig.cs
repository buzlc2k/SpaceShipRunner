using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/GameDifficultyConfig/CoinSpawnerConfig")]
public class CoinSpawnerConfig : ScriptableObject
{
    [Tooltip("Khoảng thời gian để cập nhật tỉ lệ spawn coin")] public float TimeInterval = 10f;

    [Tooltip("Tỉ lệ spawn ra coin")] public List<float> CoinSpawnRates;

    [Tooltip("Tỉ lệ coin có thể spawn/ tổng số coin")] public List<float> NumCoinSpawnedRates;
}