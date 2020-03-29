using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BvsM.Faders;
using System;

public class MeteorSplatter : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite = null;
    [SerializeField] LightFader2D[] splatterLights = null;
    [SerializeField] float fadeOutTime = 3f; 

    SpriteFader spriteFader = null;

    private void Awake() 
    {
        spriteFader = sprite.GetComponent<SpriteFader>();
    }

    // Called by animation event
    public void FadeSplatter()
    {
        spriteFader.FadeOut(fadeOutTime);
        FadeLights();
        Destroy(gameObject, fadeOutTime);
    }

    private void FadeLights()
    {
        foreach (var light in splatterLights)
        {
            light.FadeIn(fadeOutTime);
        }
    }
}
