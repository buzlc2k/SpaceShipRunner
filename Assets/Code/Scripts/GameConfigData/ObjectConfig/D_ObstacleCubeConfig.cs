using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjectConfig/ObstacleCubeConfig/D_ObstacleCubeConfig")]
public class D_ObstacleCubeConfig : ObstacleCubeConfig
{
    [Header("Movement")]
    public ObjMoveByStaticPointLoopConfig D_ObstacleCubeMovementConfig;
}