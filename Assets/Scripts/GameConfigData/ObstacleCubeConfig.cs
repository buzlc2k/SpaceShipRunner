using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObstacleCubeConfig/ObstacleCubeConfig")]
public class ObstacleCubeConfig : ScriptableObject
{
    [Header("Collision")]
    public float InitialColliderRadius;
    public ObjTagCollision InitialTagOfCollisionableObject; 
    public ObjTagCollision InitialTagOfObject;
}