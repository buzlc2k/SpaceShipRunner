using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CameraConfig/MainCameraConfig")]
public class MainCameraConfig : ScriptableObject
{
    [Header("CameraTransform")]
    public Vector3 InitialMainMenuPosition;
    public Quaternion InitialMainMenuRotation;
    public Vector3 InitialGameRunningPosition;
    public Quaternion InitialGameRunningRotation;
    public Vector3 InitialGameResultPosition;
    public Quaternion InitialGameResultRotation;
}