using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class Meteor : MonoBehaviour
{
    [SerializeField] GameObject splatterPref = null;
    [SerializeField] Light2D myLight = null;

    ParticleSystem myParticleSystem;
    CameraShaker cameraShaker;
    CircleCollider2D myCircleCollider;
    Rigidbody2D myRigidBody;

    float timer = float.Epsilon;

    private void Awake() 
    {
        cameraShaker = GetComponent<CameraShaker>();
        myParticleSystem = GetComponentInChildren<ParticleSystem>();
        myCircleCollider = GetComponent<CircleCollider2D>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        timer += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
            if (other.gameObject.layer == 8)
            {
                Vector3 impactPoint = other.GetContact(0).point;

                Impact(impactPoint);
            }
    }

    private void Impact(Vector3 impactPoint)
    {
        cameraShaker.ShakeMainCamera();

        GetComponentInChildren<SpriteRenderer>().enabled = false;
        StopEmitSmoke();

        myCircleCollider.enabled = false;

        SpawnSplatter(impactPoint);
        myRigidBody.simulated = false;
        StartCoroutine(LightFadOff());
        Destroy(gameObject, cameraShaker.duration + 10f);
    }

    private void StopEmitSmoke()
    {
        var emission = myParticleSystem.emission;
        emission.enabled = false;
    }

    private void SpawnSplatter(Vector3 impactPoint)
    {
        Instantiate(splatterPref, impactPoint, Quaternion.identity, transform);
    }

    private IEnumerator LightFadOff()
    {
        timer = 0f;
        float stratingIntensity = myLight.intensity;

        while (timer < 3f)
        {
            myLight.intensity -= Mathf.Clamp(Time.deltaTime / 3f, 0f, 1f) * stratingIntensity ;
            yield return null;
        }
    }
}
