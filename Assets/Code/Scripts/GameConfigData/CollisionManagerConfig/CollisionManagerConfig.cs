using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CollisionManagerConfig/CollisionManagerConfig")]
public class CollisionManagerConfig : ScriptableObject
{
    public Vector3 InitialCollisionableAreaCenterPoint = new(0, 0, 3.5f);
    public float InitialCollisionableAreaRadius = 7.5f;
}