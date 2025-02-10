using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjectConfig/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [Header("Movement")]
    public ObjMovementConfig PlayerMovementConfig;

    [Header("Rotation")]
    public ObjRotationConfig PlayerRotationConfig;

    [Header("Collision")]
    public ObjCollisionConfig PlayerCollisionConfig;
}