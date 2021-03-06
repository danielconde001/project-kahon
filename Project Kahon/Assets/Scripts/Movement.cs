using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObstacleDetection), typeof (PositionByCell))]
public class Movement : MonoBehaviour
{   
    [SerializeField] private Transform center, forward, back, left, right;
    [SerializeField] private float flipRate;
    [SerializeField] private float rotationByDegrees;
    
    bool canFlip = true;

    ObstacleDetection obstacleDetection;
    PositionByCell positionByCell;
    
    private void Awake() {

        if (!center) ProvideCenterObject();
    
        center.position = transform.position;

        obstacleDetection = GetComponent<ObstacleDetection>();
        positionByCell = GetComponent<PositionByCell>(); 
    }

    private void Update()
    {
        if (!canFlip) return;

        else if (Input.GetKeyDown(KeyCode.W)) 
        {
            if (NextCellIsValid(Vector3.forward))
            {
                Flip(forward.position, Vector3.right);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A)) 
        {
            if (NextCellIsValid(-Vector3.right))
            {
                Flip(left.position, Vector3.forward);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S)) 
        {
            if (NextCellIsValid(-Vector3.forward))
            {
                Flip(back.position, -Vector3.right);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D)) 
        {
            if (NextCellIsValid(Vector3.right))
            {
                Flip(right.position, -Vector3.forward);
            }
        }
    }

    private void Flip(Vector3 point, Vector3 axis)
    {
        LevelManager.OnAction();
        StartCoroutine(FlipCoroutine(point, axis));
    }

    private IEnumerator FlipCoroutine (Vector3 point, Vector3 axis)
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

    private bool NextCellIsValid(Vector3 direction)
    {
        if (!obstacleDetection.DetectObstacle(transform, direction)) { 
            if (positionByCell.ValidateCellPosition(direction))
                return true;
            else return false;
        }
        else return false;
    }

    private void ProvideCenterObject()
    {
        GameObject newGameObject = (GameObject)Instantiate(Resources.Load("Center"));
            center = newGameObject.transform;
            forward = center.transform.Find("Forward");
            back = center.transform.Find("Back");
            left = center.transform.Find("Left");
            right = center.transform.Find("Right");
    }

}
