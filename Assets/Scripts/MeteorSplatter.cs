using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BvsM.Faders;

public class MeteorSplatter : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite = null;
    [SerializeField] LightFader2D splatterLight = null;
    [SerializeField] float fadeOutTime = 3f; 

    SpriteFader spriteFader = null;

    private void Awake() 
    {
        spriteFader = sprite.GetComponent<SpriteFader>();
    }

    // Called by animation event
    public void FadeSplatter()
    {
        //if (!spriteFader || !splatterLight) { return; }
        spriteFader.FadeOut(fadeOutTime);
        splatterLight.FadeOut(fadeOutTime);
        Destroy(gameObject, fadeOutTime);
    }
}
