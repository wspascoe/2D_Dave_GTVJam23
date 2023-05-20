using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WayPoint : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;

    public int GetNextIndex(int i)
    {
        if (i + 1 == waypoints.Length)
        {
            return 0;
        }
        return i + 1;
    }

    public Vector3 GetWayPoint(int i)
    {
        return waypoints[i].position;
    }
}
