using UnityEngine;
using Cinemachine;
using System.Collections;
using System;
using System.Collections.Generic;
using DG.Tweening;

public class CameraTransition : ButMonobehavior
{    
    protected Action<KeyValuePair<EventParameterType, object>> initializeTranslateCamera;

    protected override void SetUpDelegate(){
        initializeTranslateCamera ??= param => {
            if (param.Key != EventParameterType.ChangeGameState_GameState) return;
            
            if(param.Value.Equals(GameState.Running))
                InitializeTranslateCamera(CameraController.Instance.MainCameraConfig.InitialGameRunningPosition, CameraController.Instance.MainCameraConfig.InitialGameRunningRotation);
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.ChangeGameState, initializeTranslateCamera);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.ChangeGameState, initializeTranslateCamera);
    }

    private void InitializeTranslateCamera(Vector3 targetPos, Quaternion targetRotation)
    {
        var sequence = DOTween.Sequence();

        sequence.Append(CameraController.Instance.MainCamera.transform.DOMove(targetPos, 2.5f)) 
                .Join(CameraController.Instance.MainCamera.transform.DORotateQuaternion(targetRotation, 2.5f));
    }
}