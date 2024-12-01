using UnityEngine;

/// <summary>
/// Class control the main camera of scene
/// </summary>
public class CameraController : Singleton<CameraController>
{
    /// <summary>
    /// Main Camera in Scene
    /// </summary>
    public Camera MainCamera { get; private set; }

    protected override void LoadComponents() {
        MainCamera = GetComponent<Camera>();
    }
}