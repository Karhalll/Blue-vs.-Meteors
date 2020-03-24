using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    ParticleSystem myParticleSystem;
    CameraShaker cameraShaker;

    private void Awake() 
    {
        cameraShaker = GetComponent<CameraShaker>();
        myParticleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer == 8)
        {
            cameraShaker.ShakeMainCamera();
            GetComponentInChildren<SpriteRenderer>().enabled = false;

            var emission = myParticleSystem.emission;
            emission.enabled = false;
            Destroy(gameObject, cameraShaker.duration + 10f);
        }
    }
}
