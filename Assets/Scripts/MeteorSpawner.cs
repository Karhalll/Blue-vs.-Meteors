using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [Header("Assets")]
    [SerializeField] Meteor meteorPrefab = null;
    [SerializeField] SpawnRange spawnRange = null;
    [SerializeField] Transform parent = null;

    [Header("Properities")]
    [SerializeField] float spawnTime = 1f;
    [SerializeField] int maxAtOnce = 3;

    float timer = Mathf.Epsilon;

    void Update()
    {
        if (FindObjectsOfType<Meteor>().Length < maxAtOnce)
        {
            SpawnMeteor();
        }

        UpdateTimer();
    }

    private void SpawnMeteor()
    {
        if (timer >= spawnTime)
        {
            Vector3 randomPosition = GetRandomPos();
            Meteor meteor = Instantiate(meteorPrefab,
                randomPosition, 
                Quaternion.identity,
                parent);
            
            timer = Mathf.Epsilon;
            Destroy(meteor.gameObject, 10f);
        }
    }

    private Vector3 GetRandomPos()
    {
        float start = spawnRange.start.position.x;
        float end = spawnRange.end.position.x;
        float y = spawnRange.transform.position.y;
        float z = spawnRange.transform.position.z;

        float randomX = Random.Range(start, end); 
        Vector3 randomPosition = new Vector3(randomX, y, z);
        
        return randomPosition;
    }

    private void UpdateTimer()
    {
        timer += Time.deltaTime;
    }
}
