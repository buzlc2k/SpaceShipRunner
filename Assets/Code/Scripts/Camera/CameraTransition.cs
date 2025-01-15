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
            if (param.Key != EventParameterType.ChangeGameState_GameState) return;
            
            if(param.Value.Equals(GameState.Running))
                InitializeTranslateCamera(CameraController.Instance.MainCameraConfig.InitialGameRunningPosition, CameraController.Instance.MainCameraConfig.InitialGameRunningRotation, 2.5f);
        };

        initializeTranslateCameraGameResult ??= param => {
            if (param.Key != EventParameterType.ChangeGameState_GameState) return;
            
            if(param.Value.Equals(GameState.Result))
                InitializeTranslateCamera(CameraController.Instance.MainCameraConfig.InitialGameResultPosition, CameraController.Instance.MainCameraConfig.InitialGameResultRotation, 2);
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.ChangeGameState, initializeTranslateCameraGameRunning);
        Observer.AddListener(EventID.ChangeGameState, initializeTranslateCameraGameResult);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.ChangeGameState, initializeTranslateCameraGameRunning);
        Observer.RemoveListener(EventID.ChangeGameState, initializeTranslateCameraGameResult);
    }

    private void InitializeTranslateCamera(Vector3 targetPos, Quaternion targetRotation, float timeTransition)
    {
        var cameraSequence = DOTween.Sequence();

        cameraSequence
            .Append(CameraController.Instance.MainCamera.transform.DOMove(targetPos, timeTransition)) 
            .Join(CameraController.Instance.MainCamera.transform.DORotateQuaternion(targetRotation, timeTransition));
    }
}