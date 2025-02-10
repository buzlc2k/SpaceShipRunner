using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjectConfig/ObjCollisionConfig/ObjCollisionConfig")]
public class ObjCollisionConfig : ScriptableObject
{
    public float ColliderRadius;
    public List<ObjTagCollision> TagOfCollisionableObject;
    public ObjTagCollision TagOfObject;
}