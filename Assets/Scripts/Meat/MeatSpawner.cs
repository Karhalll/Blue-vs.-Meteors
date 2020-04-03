using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BvsM.Meat
{
    public class MeatSpawner : MonoBehaviour
    {
        [SerializeField] Meat meatPref = null;
        [SerializeField] float spawnRadius = 0.5f;
        [SerializeField] float spawnTime = 5f;
        [SerializeField] float availebleTime = 5f;

        float timer = Mathf.Epsilon;

        private void Update() 
        {
            if (timer >= spawnTime)
            {
                SpawnMeat();
                timer = Mathf.Epsilon;
            }
            UpdateTimer();
        }

        private void SpawnMeat()
        {
            Meat meat = Instantiate(
                meatPref, 
                RandomPostitonInRadius(), 
                Quaternion.identity, 
                transform
                );
            Destroy(meat.gameObject, availebleTime);
        }

        private Vector3 RandomPostitonInRadius()
        {
            Vector2 randomPos = new Vector2(); 
            randomPos.x = Random.Range(-spawnRadius, spawnRadius);
            randomPos.y = Random.Range(-spawnRadius, spawnRadius);
            Vector2 clampedRandom = Vector2.ClampMagnitude(randomPos, spawnRadius);

            return transform.position + (Vector3)clampedRandom;
        }

        private void UpdateTimer()
        {
            timer += Time.deltaTime;
        }

        private void OnDrawGizmos() 
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
    }
}
