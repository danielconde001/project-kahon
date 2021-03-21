using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GridManager : MonoBehaviour
{
    [SerializeField] uint columns, rows;
    public uint Columns {get {return columns;}}
    public uint Rows {get {return rows;}}

    public void CreateGrid()
    {
        for (int a = 0; a < columns; a++)
        {
            for (int b = 0; b < columns; b++) 
            {
                GameObject spawnedGridCell = (GameObject)Instantiate(Resources.Load("Grid Cell"));
                spawnedGridCell.transform.parent = this.transform;
                spawnedGridCell.transform.position = new Vector3(a, 0, b);
            }
        }
    }
}
