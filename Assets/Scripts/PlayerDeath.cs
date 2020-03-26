using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] bool isInvincible = false;
    [SerializeField] UnityEvent deathEvent = null;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Meteor" && !isInvincible)
        {
            Die();
        }
    }

    private void Die()
    {
        deathEvent.Invoke();
    }
}
