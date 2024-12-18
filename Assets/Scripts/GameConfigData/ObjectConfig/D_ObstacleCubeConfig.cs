using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObstacleCubeConfig/D_ObstacleCubeConfig")]
public class D_ObstacleCubeConfig : ObstacleCubeConfig
{
    [Header("Movement")]
    public float InitialMoveSpeed;
    public Vector3 InitialSpawnPoint;
    public Vector3 InitialTargetPoint;
    public int InitialRemainingLoops; 
}