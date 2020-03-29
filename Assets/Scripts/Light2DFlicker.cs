using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Experimental.Rendering.Universal;

using BvsM.Faders;

public class Light2DFlicker : MonoBehaviour
{
    [Curve(0, 0, 1f, 1f, true)]
    [SerializeField] AnimationCurve flickerCurve = null;
    [SerializeField] int frequency = 8;

    Light2D myLight = null;

    float lightStartingIntensity = 1f;

    private void Awake()
    {
        myLight = GetComponent<Light2D>();
    }

    private void Start()
    {
        lightStartingIntensity = myLight.intensity;
    }

    private void LateUpdate() 
    {
        float time = ((float)(((int)(Time.realtimeSinceStartup * 10000f)) % 10000)) / 10000f;
        float frequenced = ((float)(((int)(time * 10000f)) % ((int)10000/frequency))) / 10000f;
        
        if (myLight.GetComponent<LightFader2D>().IsRunningCoroutine())
        {
            myLight.intensity = flickerCurve.Evaluate(frequenced) * myLight.intensity;

        }
        else
        {
            myLight.intensity = flickerCurve.Evaluate(frequenced) * lightStartingIntensity;
        }

        
    }
}
