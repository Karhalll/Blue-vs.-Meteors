using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class VirtualCameraShaker : MonoBehaviour
{
    [SerializeField] float shakeDuration = 4f;
    [SerializeField] float shakeAmplitude = 4f;
    [SerializeField] float shakeFrequency = 4f;

    CinemachineVirtualCamera virtualCamera;
    CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    float shakeElapsedTime = 0f;


    private void Awake() 
    {
        virtualCamera = GameObject.FindGameObjectWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
        virtualCameraNoise = virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeVirtualCamera()
    {
        //StopAllCoroutines();
        shakeElapsedTime = shakeDuration;
        StartCoroutine(ShakeCamera());
    }

    private IEnumerator ShakeCamera()
    {
        while (shakeElapsedTime > 0f)
        {
            virtualCameraNoise.m_AmplitudeGain = shakeAmplitude;
            virtualCameraNoise.m_FrequencyGain = shakeFrequency;

            shakeElapsedTime -= Time.deltaTime;
        
            yield return null;
        }

        virtualCameraNoise.m_AmplitudeGain = 0f;
        shakeElapsedTime = 0f;
    }
}