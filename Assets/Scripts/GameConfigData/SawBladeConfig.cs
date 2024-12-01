using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObstacleCubeConfig/SawBladeConfig")]
public class SawBladeConfig : D_ObstacleCubeConfig
{
    [Header("Rotation")]
    public float InitialRotateSpeed;
    public Vector3 InitialSpawnAngle;
    public Vector3 InitialTargetAngle;
}