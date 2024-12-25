using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjectConfig/CoinCubeConfig")]
public class CoinCubeConfig : ScriptableObject
{
    [Header("Movement")]
    public float InitialMoveSpeed;
    public Vector3 InitialSpawnPoint;
    public Vector3 InitialTargetPoint;
    public int InitialRemainingLoops; 

    [Header("Rotation")]
    public float InitialRotateSpeed;
    public Vector3 InitialSpawnAngle;
    public Vector3 InitialTargetAngle;

    [Header("Collision")]
    public float InitialColliderRadius;
    public List<ObjTagCollision> InitialTagOfCollisionableObject; 
    public ObjTagCollision InitialTagOfObject;
}