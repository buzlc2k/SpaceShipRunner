using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjectConfig/ObstacleTileConfig")]
public class ObstacleTileConfig : ScriptableObject
{
    [Header("Movement")]
    public ObjMovementConfig ObstacleTileMovementConfig;

    [Header("Despawning")]
    public ObjDespawnByDistanceConfig ObstacleTileDespawnConfig;

    [Header("ObstacleCubeTransform")]
    public List<Vector3> ObstacleCubePosition;

    [Header("SpawningItem")]
    public List<Vector3> AvailablePositionToSpawnItem;
}