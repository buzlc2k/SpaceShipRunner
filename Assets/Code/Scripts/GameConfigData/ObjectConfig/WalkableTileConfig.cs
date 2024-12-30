using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjectConfig/WalkableTileConfig")]
public class WalkableTileConfig : ScriptableObject
{
    [Header("Movement")]
    public float InitialMoveSpeed;
    public Vector3 InitialSpawnPoint;
    public Vector3 InitialTargetPoint;
    public int InitialRemainingLoops; 
}