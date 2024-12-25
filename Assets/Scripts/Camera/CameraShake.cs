using UnityEngine;
using Cinemachine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CameraShake : ButMonobehavior
{
    private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;      
    protected Action<KeyValuePair<EventParameterType, object>> initializeShakeCameraDelegate;
    protected override void OnEnable()
    {
        base.OnEnable();

        SetUpDelegate();
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        Observer.RemoveListener(EventID.Player_Collide, initializeShakeCameraDelegate);
        Observer.RemoveListener(EventID.B_Cube_Collide, initializeShakeCameraDelegate);
        Observer.RemoveListener(EventID.W_Cube_Collide, initializeShakeCameraDelegate);
    }

    protected override void LoadComponents() {
        base.LoadComponents();

        cinemachineBasicMultiChannelPerlin = CameraController.Instance.CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    protected virtual void SetUpDelegate(){
        initializeShakeCameraDelegate ??= param => {
            InitializeShakeCamera(0.1f, 1.5f);
        };

        Observer.AddListener(EventID.Player_Collide, initializeShakeCameraDelegate);
        Observer.AddListener(EventID.B_Cube_Collide, initializeShakeCameraDelegate);
        Observer.AddListener(EventID.W_Cube_Collide, initializeShakeCameraDelegate);
    }

    private void InitializeShakeCamera(float shakeTimer, float shakeAmplitude){

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = shakeAmplitude;

        StartCoroutine(C_ResetShakeCamera(shakeTimer, shakeAmplitude));
    }

    private IEnumerator C_ResetShakeCamera(float shakeTimer, float shakeAmplitude){
        float shakeTime = shakeTimer;
        while(shakeTimer > 0){
            shakeTimer -= Time.deltaTime;
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = (shakeTimer/shakeTime)*shakeAmplitude;
            if(shakeTimer <= 0){
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;

                CameraController.Instance.MainCamera.transform.SetPositionAndRotation(CameraController.Instance.MainCameraConfig.InitialPosition
                                                                                        , CameraController.Instance.MainCameraConfig.InitialRotation);
            }
            yield return null;
        }

        yield break;
    }
}