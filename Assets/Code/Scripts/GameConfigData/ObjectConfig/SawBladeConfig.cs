using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjectConfig/ObstacleCubeConfig/SawBladeConfig")]
public class SawBladeConfig : D_ObstacleCubeConfig
{
    [Header("Rotation")]
    public ObjRotateByStaticEulerAngleLoopConfig SawBladeRotationConfig;
}