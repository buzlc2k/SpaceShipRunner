using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CameraConfig/MainCameraConfig")]
public class MainCameraConfig : ScriptableObject
{
    [Header("CameraTransform")]
    public Vector3 MainMenuPosition;
    public Quaternion MainMenuRotation;
    public Vector3 GameRunningPosition;
    public Quaternion GameRunningRotation;
    public Vector3 GameResultPosition;
    public Quaternion GameResultRotation;
}