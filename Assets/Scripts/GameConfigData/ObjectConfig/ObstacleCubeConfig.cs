using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObstacleCubeConfig/ObstacleCubeConfig")]
public class ObstacleCubeConfig : ScriptableObject
{
    [Header("Collision")]
    public float InitialColliderRadius;
    public List<ObjTagCollision> InitialTagOfCollisionableObject; 
    public ObjTagCollision InitialTagOfObject;
    public List<ObjTagCollision> InitialTargetTagOfCollisionableObject;
    public ObjTagCollision InitialTargetTagOfObject;
}