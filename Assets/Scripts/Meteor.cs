using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using BvsM.Platforms;

public class Meteor : MonoBehaviour
{
    [SerializeField] SpriteRenderer meteorSprite = null;
    [SerializeField] GameObject splatterPref = null;
    [SerializeField] GameObject myLight = null;
    [SerializeField] UnityEvent inpactEvent = null;

    ParticleSystem myParticleSystem;
    CircleCollider2D myCircleCollider;
    Rigidbody2D myRigidBody;

    bool wasVisible = false;

    private void Awake() 
    {
        myParticleSystem = GetComponentInChildren<ParticleSystem>();
        myCircleCollider = GetComponent<CircleCollider2D>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer == 8)
        {
            Vector2 impactPoint = other.ClosestPoint(transform.position);
            Impact(impactPoint);
        }
        else if (other.gameObject.layer == 13)
        {
            Vector2 impactPoint = other.ClosestPoint(transform.position);
            Impact(impactPoint, other.gameObject);
        }
        else if (other.gameObject.layer == 12)
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameVisible() 
    {
        wasVisible = true;
    }

    private void Impact(Vector3 impactPoint)
    {
        if (wasVisible)
        {
            inpactEvent.Invoke();
            SpawnSplatter(impactPoint);
        }
        
        StopEmitSmoke();
        DisableComponents();

        Destroy(gameObject, 2f);
    }

    private void Impact(Vector3 impactPoint, GameObject platform)
    {
        if (wasVisible)
        {
            inpactEvent.Invoke();
            SpawnSplatterOnMovable(impactPoint, platform);
        }

        StopEmitSmoke();
        DisableComponents();

        Destroy(gameObject, 2f);
    }

    private void DisableComponents()
    {
        meteorSprite.enabled = false;
        myCircleCollider.enabled = false;
        myLight.gameObject.SetActive(false);
        myRigidBody.simulated = false;
    }

    private void StopEmitSmoke()
    {
        var emission = myParticleSystem.emission;
        emission.enabled = false;
    }

    private void SpawnSplatter(Vector3 impactPoint)
    {
        Instantiate(splatterPref, impactPoint, Quaternion.identity);
    }

    private void SpawnSplatterOnMovable(Vector3 impactPoint, GameObject platform)
    {
        Transform platformSprite = platform.GetComponentInParent<MovingPlatform>().GetPlatform();
        GameObject splatter = Instantiate(splatterPref, impactPoint, platformSprite.rotation, platformSprite);   
    }
}
