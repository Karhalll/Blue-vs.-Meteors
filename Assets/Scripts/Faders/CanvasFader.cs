using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BvsM.Faders
{
    public class CanvasFader : MonoBehaviour
    {
        [SerializeField] float delay = 0f;

        CanvasGroup canvasGroup;
        Coroutine currentActiveFade = null;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void FadeOutImmediate()
        {
            canvasGroup.alpha = 1;
        }

        public void FadeOut(float time)
        {
            Fade(1, time);
        }

        public void FadeIn(float time)
        {
            Fade(0, time);
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
            yield return new WaitForSeconds(delay);

            while (!Mathf.Approximately(canvasGroup.alpha, target))
            {
                canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, target, Time.deltaTime / time);
                yield return null;
            }
        }
    }
}

