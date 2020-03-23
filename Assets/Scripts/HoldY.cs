using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HoldY : MonoBehaviour
{
    Transform parent;

    private void Awake() 
    {
        parent = transform.parent;
    }

    private void Update() 
    {
        transform.position = new Vector2(
            transform.position.x,
            parent.position.y);
    }
}
