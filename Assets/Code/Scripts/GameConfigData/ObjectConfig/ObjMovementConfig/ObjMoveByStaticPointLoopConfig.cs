using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjectConfig/ObjMovementConfig/ObjMoveByStaticPointLoopConfig")]
public class ObjMoveByStaticPointLoopConfig : ObjMovementConfig
{
    public Vector3 SpawnPoint;
    public Vector3 TargetPoint;
    public int RemainingLoops; 
    public float ResetDistanceThreshold = 0.1f;
    [Tooltip("True if Object is moving based on parent position")] public bool MoveByLocalPoint;
}