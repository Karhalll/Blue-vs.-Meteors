using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] float magnitude = 4f;
    [SerializeField] public float duration = 4f;

    Camera mainCamera;

    private void Awake() 
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    public void ShakeMainCamera()
    {
        StartCoroutine(ShakeCamera());
    }

    private IEnumerator ShakeCamera()
    {
        Vector3 cameraOriginPos = mainCamera.transform.position;
        float timer = Mathf.Epsilon;

        while (duration > timer)
        {
            float randomX = Random.Range(-1f, 1f) * magnitude;
            float randomY = Random.Range(-1f, 1f) * magnitude;

            Vector3 newPos = new Vector3(
                cameraOriginPos.x + randomX,
                cameraOriginPos.y + randomY,
                cameraOriginPos.z
            );

            mainCamera.transform.position = newPos;

            timer += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = cameraOriginPos;
    }

    
}
