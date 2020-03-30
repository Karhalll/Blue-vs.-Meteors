using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BvsM.Platforms
{
    [ExecuteInEditMode]
    public class PlatformLimit : MonoBehaviour
    {
        [SerializeField] MovingPlatform platform = null;
        [SerializeField] Transform up = null;
        [SerializeField] Transform down = null;

        private void Update()
        {
            up.position = (Vector2)platform.transform.position + platform.movementVector;
            down.position = (Vector2)platform.transform.position - platform.movementVector;     
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(up.position, down.position);
        }

    }
}


