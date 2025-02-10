using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjectConfig/CoinCubeConfig")]
public class CoinCubeConfig : ScriptableObject
{
    [Header("Movement")]
    public ObjMoveByStaticPointLoopConfig CoinCubeMovementConfig;

    [Header("Rotation")]
    public ObjRotateByStaticEulerAngleLoopConfig CoinRotationConfig;

    [Header("Collision")]
    public ObjCollisionConfig CoinCollisionConfig;
}