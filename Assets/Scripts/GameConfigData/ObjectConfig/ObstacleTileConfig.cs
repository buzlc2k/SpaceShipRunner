using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjectConfig/ObstacleTileConfig")]
public class ObstacleTileConfig : ScriptableObject
{
    [Header("Movement")]
    public float InitialMoveSpeed;

    [Header("Despawning")]
    public Vector3 InitialPosToCalculateDespawn;
    public float InitialDisToDespawn;

    [Header("ObstacleCubeTransform")]
    public List<Vector3> ObstacleCubePosition;

    [Header("SpawningItem")]
    public List<Vector3> AvailablePositionToSpawnItem;
}