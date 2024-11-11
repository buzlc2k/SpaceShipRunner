using UnityEngine;

/// <summary>
/// Class control the main camera of scene
/// </summary>
public class CameraController : Singleton<CameraController>
{
    /// <summary>
    /// Main Camera in Scene
    /// </summary>
    public Camera MyCamera { get; private set; }

    private void Awake() {
        MyCamera = GetComponent<Camera>();
    }
}