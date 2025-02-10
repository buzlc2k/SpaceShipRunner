using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CollisionManagerConfig/CollisionManagerConfig")]
public class CollisionManagerConfig : ScriptableObject
{
    public Vector3 CollisionableAreaCenterPoint = new(0, 0, 3.5f);
    public float CollisionableAreaRadius = 7.5f;
}