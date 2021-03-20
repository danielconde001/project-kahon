﻿using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridManager))]
public class GridManagerEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GridManager gridManager = (GridManager)target;
        if (GUILayout.Button("Create Grid"))
        {
            gridManager.CreateGrid();
        }
    }
}
