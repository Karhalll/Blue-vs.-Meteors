using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Experimental.Rendering.Universal;

namespace BvsM.Faders
{
    [RequireComponent(typeof(Light2D))]
    public class LightFader2D : MonoBehaviour
    {
        [Curve(0,0,1f,1f, true)]
        [SerializeField] AnimationCurve FadingCurve = null;

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
            float timeValue = 0f;

            while (timeValue < time)
            {
                myLight.intensity = FadingCurve.Evaluate(timeValue / time) * target;

                timeValue += Time.deltaTime;
                yield return null;
            }
        }

        public bool IsRunningCoroutine()
        {
            if (currentActiveFade == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}