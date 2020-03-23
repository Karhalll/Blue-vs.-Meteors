using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRange : MonoBehaviour
{
    [SerializeField] float sphereRadius = 0.3f;

    public Transform start;
    public Transform end;

    private void Awake() 
    {
        start = transform.GetChild(0);
        end = transform.GetChild(1);
    }

    private void Start() 
    {
        SortRangePointsByX();
    }

    private void SortRangePointsByX()
    {
        float startX = start.position.x;
        float endX = end.position.x;

        if (startX > endX)
        {
            Transform hold = start;
            start = end;
            end = hold;
        }
    } 

    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int j = GetNextIndex(i);

            Gizmos.DrawSphere(GetWaypoint(i), sphereRadius);
            Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(j));
        }
    }

    private int GetNextIndex(int i)
    {
        if (i == transform.childCount - 1)
        {
            return 0;
        }
        return i + 1;
    }

    private Vector2 GetWaypoint(int i)
    {
        return transform.GetChild(i).position;
    }
}
