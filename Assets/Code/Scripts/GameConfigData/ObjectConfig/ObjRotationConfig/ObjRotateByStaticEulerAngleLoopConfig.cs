using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjectConfig/ObjRotationConfig/ObjRotateByStaticEulerAngleLoopConfig")]
public class ObjRotateByStaticEulerAngleLoopConfig : ObjRotationConfig
{
    public Vector3 SpawnAngle; 
    public Vector3 TargetAngle;
}