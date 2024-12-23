using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [Header("Movement")]
    public float InitialMoveSpeed;

    [Header("Rotation")]
    public float InitialRotateSpeed;

    [Header("Collision")]
    public float InitialColliderRadius;
    public List<ObjTagCollision> InitialTagOfCollisionableObject;
    public ObjTagCollision InitialTagOfObject;
    public List<ObjTagCollision> InitialTargetTagOfCollisionableObject;
    public ObjTagCollision InitialTargetTagOfObject;
}