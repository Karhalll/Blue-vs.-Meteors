using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [Range(0,100)]
    [SerializeField] int damageToPlayer = 50;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            DealDamageTo(other);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            DealDamageTo(other);
        }
    }

    private void DealDamageTo(Collision2D other)
    {
        other.gameObject.GetComponent<PlayersLife>().GetDamage(damageToPlayer);
    }

    private void DealDamageTo(Collider2D other)
    {
        other.gameObject.GetComponent<PlayersLife>().GetDamage(damageToPlayer);
    }


}
