using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObstacleDetection))]
public class Movement : MonoBehaviour
{   
    [SerializeField] private Transform center, forward, back, left, right;
    [SerializeField] private float flipRate;
    [SerializeField] private float rotationByDegrees;
    
    bool canFlip = true;

    ObstacleDetection obstacleDetection;

    private void Awake() {
        obstacleDetection = GetComponent<ObstacleDetection>();    
    }

    private void Update()
    {
        if (!canFlip) return;

        else if (Input.GetKeyDown(KeyCode.W)) 
        {
            if (!obstacleDetection.DetectObstacle(transform, Vector3.forward))
                StartCoroutine(Flip(forward.position, Vector3.right));
        }
        else if (Input.GetKeyDown(KeyCode.A)) 
        {
            if (!obstacleDetection.DetectObstacle(transform, -Vector3.right))
                StartCoroutine(Flip(left.position, Vector3.forward));
        }
        else if (Input.GetKeyDown(KeyCode.S)) 
        {
            if (!obstacleDetection.DetectObstacle(transform, -Vector3.forward))
                StartCoroutine(Flip(back.position, -Vector3.right));
        }
        else if (Input.GetKeyDown(KeyCode.D)) 
        {
            if (!obstacleDetection.DetectObstacle(transform, Vector3.right))
                StartCoroutine(Flip(right.position, -Vector3.forward));
        }
    }

    public IEnumerator Flip (Vector3 point, Vector3 axis)
    {
        canFlip = false;
        for (int i = 0; i < rotationByDegrees / flipRate; i++)
        {
            transform.RotateAround(point, axis, flipRate);
            yield return new WaitForEndOfFrame();
        }
        center.position = transform.position;
        canFlip = true;
    }
}
