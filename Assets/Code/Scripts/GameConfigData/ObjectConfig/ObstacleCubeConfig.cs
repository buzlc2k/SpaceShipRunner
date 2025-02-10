using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjectConfig/ObstacleCubeConfig/ObstacleCubeConfig")]
public class ObstacleCubeConfig : ScriptableObject
{
    [Header("Collision")]
    public ObjCollisionConfig ObstacleCubeCollisionConfig;
}