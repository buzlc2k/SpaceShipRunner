using UnityEngine;
using Cinemachine;
using System.Collections;
using System;
using System.Collections.Generic;

/// <summary>
/// Class control the main camera of scene
/// </summary>
public class CameraController : Singleton<CameraController>
{
    public CameraShake CameraShake;
    public CinemachineVirtualCamera CinemachineVirtualCamera;
    public Camera MainCamera;
    public MainCameraConfig MainCameraConfig;

    protected override void LoadComponents() {
        base.LoadComponents();

        if(MainCamera == null) MainCamera = GetComponent<Camera>();
        if(CinemachineVirtualCamera == null) CinemachineVirtualCamera =  GetComponentInChildren<CinemachineVirtualCamera>();
        if(CameraShake == null) CameraShake = GetComponentInChildren<CameraShake>();
    }
}