using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionByCell : MonoBehaviour
{
    [SerializeField] GridManager gridManager;
    [SerializeField] private Vector2 initialCellPosition;
    [SerializeField] private Vector2 cellPosition;
    
    private void Awake() {
        transform.position = new Vector3(initialCellPosition.x, .5f, initialCellPosition.y);
        cellPosition = initialCellPosition;
    }

    public bool ValidateCellPosition(Vector3 direction)
    {
        Vector2 addedDirection = new Vector2(direction.x, direction.z);
        cellPosition += addedDirection;

        if (cellPosition.x < 0 || cellPosition.x >= (int)gridManager.Rows)
        {
            cellPosition -= addedDirection;
            return false;
        }
        else if (cellPosition.y < 0 || cellPosition.y >= (int)gridManager.Columns)
        {
            cellPosition -= addedDirection;
            return false;
        }
        else return true;
    }
}
