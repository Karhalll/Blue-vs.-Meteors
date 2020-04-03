using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 playerStartingPosition =
                other.gameObject.GetComponentInParent<PlayerControler>().GetStartingPosition();

            other.gameObject.transform.position = playerStartingPosition;
        }
    }
}
