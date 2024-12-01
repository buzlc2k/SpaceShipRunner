using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObstacleTileConfig")]
public class ObstacleTileConfig : ScriptableObject
{
    [Header("Movement")]
    public float InitialMoveSpeed;

    [Header("Despawning")]
    public Vector3 InitialPosToCalculateDespawn;
    public float InitialDisToDespawn;
}