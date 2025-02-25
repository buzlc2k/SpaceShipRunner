using UnityEngine;
using Cinemachine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CameraShake : ButMonobehavior
{
    private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;      
    protected Action<KeyValuePair<EventParameterType, object>> initializeShakeCameraDelegate;

    protected override void LoadComponents() {
        base.LoadComponents();

        cinemachineBasicMultiChannelPerlin = CameraController.Instance.CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    protected override void SetUpDelegate(){
        initializeShakeCameraDelegate ??= param => {
            InitializeShakeCamera(0.08f, 1.5f * (165/(1/Time.deltaTime)));
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.Player_Collide, initializeShakeCameraDelegate);
        Observer.AddListener(EventID.ObstacleCube_Collide, initializeShakeCameraDelegate);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.Player_Collide, initializeShakeCameraDelegate);
        Observer.RemoveListener(EventID.ObstacleCube_Collide, initializeShakeCameraDelegate);
    }

    private void InitializeShakeCamera(float shakeDuration, float shakeAmplitude){
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = shakeAmplitude;

        StartCoroutine(C_ResetShakeCamera(shakeDuration, shakeAmplitude));
    }

    private IEnumerator C_ResetShakeCamera(float shakeDuration, float shakeAmplitude){
        float elapsedTime = 0f; 
        
        while (elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;

            float currentAmplitude = shakeAmplitude * (1 - elapsedTime / shakeDuration);
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = currentAmplitude;

            yield return null; 
        }

        SetCameraDefaultTransform();
    }

    private void SetCameraDefaultTransform(){
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
        CameraController.Instance.MainCamera.transform.SetPositionAndRotation(
            CameraController.Instance.MainCameraConfig.GameRunningPosition,
            CameraController.Instance.MainCameraConfig.GameRunningRotation
        );
    }
}