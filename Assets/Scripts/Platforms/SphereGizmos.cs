using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGizmos : MonoBehaviour
{
    [SerializeField] Color color = Color.red;
    [SerializeField] float radius = 0.2f;

    private void OnDrawGizmos() 
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
