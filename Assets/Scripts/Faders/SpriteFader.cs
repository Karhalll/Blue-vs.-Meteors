using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BvsM.Faders
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteFader : MonoBehaviour
    {
        SpriteRenderer mySprite = null;
        Coroutine currentActiveFade = null;

        float spriteStartingAlpha = 1f;

        private void Awake()
        {
            mySprite = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            spriteStartingAlpha = mySprite.color.a;
        }

        public void FadeOutImmediate()
        {
            Color aplha0 = new Color(
                mySprite.color.r,
                mySprite.color.g,
                mySprite.color.b,
                0f
            );
            
            mySprite.color = aplha0;
        }

        public void FadeOut(float time)
        {
            Fade(0, time);
        }

        public void FadeIn(float time)
        {
            Fade(spriteStartingAlpha, time);
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
            while (!Mathf.Approximately(spriteStartingAlpha, target))
            {
                float newAlpha = Mathf.MoveTowards(mySprite.color.a, target, Time.deltaTime / time);
                Color changingAplha = new Color(
                mySprite.color.r,
                mySprite.color.g,
                mySprite.color.b,
                newAlpha
                );

                mySprite.color = changingAplha;
                yield return null;
            }
        }
    }

}
