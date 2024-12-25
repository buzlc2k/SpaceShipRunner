using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CameraConfig/MainCameraConfig")]
public class MainCameraConfig : ScriptableObject
{
    [Header("CameraTransform")]
    public Vector3 InitialPosition;
    public Quaternion InitialRotation;
    public Vector3 InitialScale;
}