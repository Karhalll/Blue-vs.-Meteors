using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BvsM.Platforms
{
    public class RotatingPlatform : MonoBehaviour
    {
        [SerializeField] Transform platform = null;
        [SerializeField] float maxAngel = 0f;
        [Range(1, 10)]
        [SerializeField] float period = 5f;

        Vector3 startingPos;
        float rotationFactor;

        private void Update()
        {
            if (period <= Mathf.Epsilon) { return; } // protect against period is zero
            float cycles = Time.time / period; // grows continually from 0

            const float tau = Mathf.PI * 2f; // about 6.28
            float rawSinWave = Mathf.Sin(cycles * tau); // goes from -1 to +1

            startingPos = transform.position;

            rotationFactor = rawSinWave / 2f;

            float newRotation = rotationFactor * maxAngel;
            platform.rotation = Quaternion.Euler(0f, 0f, newRotation);
        }
    }
}
