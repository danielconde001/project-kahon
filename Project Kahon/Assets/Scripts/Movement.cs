using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform center, forward, back, left, right;
    [SerializeField] private float flipRate;
    [SerializeField] private float rotationByDegrees;
    
    bool canFlip = true;

    private void Update()
    {
        if (!canFlip) return;

        else if (Input.GetKeyDown(KeyCode.W)) StartCoroutine(Flip(forward.position, Vector3.right));
        else if (Input.GetKeyDown(KeyCode.A)) StartCoroutine(Flip(left.position, Vector3.forward));
        else if (Input.GetKeyDown(KeyCode.S)) StartCoroutine(Flip(back.position, -Vector3.right));
        else if (Input.GetKeyDown(KeyCode.D)) StartCoroutine(Flip(right.position, -Vector3.forward));
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
