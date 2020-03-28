using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Experimental.Rendering.Universal;

namespace BvsM.Faders
{
    [RequireComponent(typeof(Light2D))]
    public class LightFader2D : MonoBehaviour
    {
        Light2D myLight = null;
        Coroutine currentActiveFade = null;

        float lightStartingIntensity = 1f;

        private void Awake() 
        {
            myLight = GetComponent<Light2D>();
        }

        private void Start() 
        {
            lightStartingIntensity = myLight.intensity;
        }

        public void FadeOutImmediate()
        {
            myLight.intensity = 0;
        }

        public void FadeOut(float time)
        {
            Fade(0, time);
        }

        public void FadeIn(float time)
        {
            Fade(lightStartingIntensity, time);
        }

        private void Fade(float target, float time)
        {
            if (currentActiveFade != null)
            {
                StopCoroutine(currentActiveFade);
            }
            currentActiveFade = StartCoroutine(FadeRoutine(target, time));
        }

        private IEnumerator FadeRoutine(float target, float time)
        {
            while (!Mathf.Approximately(lightStartingIntensity, target))
            {
                myLight.intensity = Mathf.MoveTowards(myLight.intensity, target, Time.deltaTime / time);
                yield return null;
            }
        }
    }

}