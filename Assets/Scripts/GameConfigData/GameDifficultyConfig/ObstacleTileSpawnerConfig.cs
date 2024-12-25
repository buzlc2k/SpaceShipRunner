using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/GameDifficultyConfig/ObstacleTileSpawnerConfig")]
public class ObstacleTileSpawnerConfig : ScriptableObject
{
    [Tooltip("Khoảng thời gian để cập nhật danh sách obstacle")] public float TimeInterval = 10f;
    public List<ObstacleTilePrefabs> ObstacleTilePrefabs = new();
}

[Serializable]
public class ObstacleTilePrefabs{
    public List<GameObject> L_ObstacleTilePrefabs = new();
}