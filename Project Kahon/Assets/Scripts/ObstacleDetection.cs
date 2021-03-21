using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetection : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    public bool DetectObstacle(Transform rayOrigin, Vector3 direction)
    {
       if (Physics.Raycast(rayOrigin.position, direction, 1f, layerMask))
       {
           return true;
       }

       else return false;
    }
}
