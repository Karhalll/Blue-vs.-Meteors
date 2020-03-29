using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
[SerializeField] Transform point = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 impactPoint = other.ClosestPoint(transform.position);  

        Debug.DrawRay(impactPoint, Vector2.down);
        Debug.DrawRay(impactPoint, Vector2.right);

        Debug.DrawRay(point.position, Vector2.down, Color.blue);
        Debug.DrawRay(point.position, Vector2.right, Color.blue);

        Vector2 impactPoint2 = other.bounds.ClosestPoint(point.position);
        Debug.DrawRay(impactPoint, Vector2.down, Color.red);
        Debug.DrawRay(impactPoint, Vector2.right, Color.red);

    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Vector2 impactPointGround = other.GetContact(0).point;

        Debug.DrawRay(impactPointGround, Vector2.down, Color.red);
        Debug.DrawRay(impactPointGround, Vector2.right, Color.red);
    }
}
