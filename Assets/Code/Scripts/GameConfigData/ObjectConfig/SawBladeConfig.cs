using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjectConfig/ObstacleCubeConfig/SawBladeConfig")]
public class SawBladeConfig : D_ObstacleCubeConfig
{
    [Header("Rotation")]
    public float InitialRotateSpeed;
    public Vector3 InitialSpawnAngle;
    public Vector3 InitialTargetAngle;
}