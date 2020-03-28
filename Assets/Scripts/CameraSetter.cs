using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSetter : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera = null;

    CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    private void Awake() 
    {
        virtualCameraNoise = virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

    // Start is called before the first frame update
    void Start()
    {
        virtualCameraNoise.m_AmplitudeGain = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
