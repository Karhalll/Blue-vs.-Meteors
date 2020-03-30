using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HoldX : MonoBehaviour
{
    Transform parent;

    private void Awake()
    {
        parent = transform.parent;
    }

    private void Update()
    {
        transform.position = new Vector2(
            parent.position.x,
            transform.position.y);
    }
}
