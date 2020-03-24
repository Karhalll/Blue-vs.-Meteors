using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    CameraShaker cameraShaker;

    private void Awake() 
    {
        cameraShaker = GetComponent<CameraShaker>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer == 8)
        {
            cameraShaker.ShakeMainCamera();
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            Destroy(gameObject, cameraShaker.duration + 1f);
        }
    }
}
