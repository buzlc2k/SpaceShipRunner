using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObstacleTileSpawnerConfig")]
public class ObstacleTileSpawnerConfig : ScriptableObject
{
    [Tooltip("Khoảng thời gian để cập nhật danh sách obstacle")] public float TimeInterval = 10f;
    public List<GameObject> ObstacleTilePrefabs_1 = new();
    public List<GameObject> ObstacleTilePrefabs_2 = new();
    public List<GameObject> ObstacleTilePrefabs_3 = new();
}