using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BvsM.Meat
{
    public class Meat : MonoBehaviour
    {
        [SerializeField] LifeManager lifeManager = null;
        [SerializeField] int healthBoost = 50;

        CircleCollider2D myBoxCollider = null;

        private void Awake() 
        {
            myBoxCollider = GetComponent<CircleCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            lifeManager.AddHealth(healthBoost);
            Destroy(gameObject);
        }
    }
}