using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjectConfig/ObjRotationConfig/ObjRotationConfig")]
public class ObjRotationConfig : ScriptableObject
{
    public float RotateSpeed;
    public float RotationThreshold = 0.1f;
}