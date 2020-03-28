﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using UnityEngine.Experimental.Rendering.Universal;


public class Meteor : MonoBehaviour
{
    [SerializeField] SpriteRenderer meteorSprite = null;
    [SerializeField] GameObject splatterPref = null;
    [SerializeField] Light2D myLight = null;
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

    private void OnCollisionEnter2D(Collision2D other) 
    {
            if (other.gameObject.layer == 8)
            {
                Vector3 impactPoint = other.GetContact(0).point;
                Impact(impactPoint);
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
        }
        
        StopEmitSmoke();
        DisableComponents();
        SpawnSplatter(impactPoint);

        Destroy(gameObject, 2f);
    }

    private void DisableComponents()
    {
        meteorSprite.enabled = false;
        myCircleCollider.enabled = false;
        myLight.intensity = 0f;
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
}
