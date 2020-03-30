using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BvsM.Platforms
{
    public class MovingRange : MonoBehaviour
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
            SortRangePointsByY();
        }

        private void SortRangePointsByY()
        {
            float startY = start.position.y;
            float endY = end.position.y;

            if (startY > endY)
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

}