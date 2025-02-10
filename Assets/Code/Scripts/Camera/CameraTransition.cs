using UnityEngine;
using Cinemachine;
using System.Collections;
using System;
using System.Collections.Generic;
using DG.Tweening;

public class CameraTransition : ButMonobehavior
{    
    protected Action<KeyValuePair<EventParameterType, object>> initializeTranslateCameraGameRunning;
    protected Action<KeyValuePair<EventParameterType, object>> initializeTranslateCameraGameResult;

    protected override void SetUpDelegate(){
        initializeTranslateCameraGameRunning ??= param => {
            InitializeTranslateCamera(CameraController.Instance.MainCameraConfig.GameRunningPosition, CameraController.Instance.MainCameraConfig.GameRunningRotation, 2.5f);
        };

        initializeTranslateCameraGameResult ??= param => {
            InitializeTranslateCamera(CameraController.Instance.MainCameraConfig.GameResultPosition, CameraController.Instance.MainCameraConfig.GameResultRotation, 2);
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.EnterGameRunningState, initializeTranslateCameraGameRunning);
        Observer.AddListener(EventID.EnterGameResultState, initializeTranslateCameraGameResult);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.EnterGameRunningState, initializeTranslateCameraGameRunning);
        Observer.RemoveListener(EventID.EnterGameResultState, initializeTranslateCameraGameResult);
    }

    private void InitializeTranslateCamera(Vector3 targetPos, Quaternion targetRotation, float timeTransition)
    {
        var cameraSequence = DOTween.Sequence();

        cameraSequence
            .Append(CameraController.Instance.MainCamera.transform.DOMove(targetPos, timeTransition)) 
            .Join(CameraController.Instance.MainCamera.transform.DORotateQuaternion(targetRotation, timeTransition));
    }
}