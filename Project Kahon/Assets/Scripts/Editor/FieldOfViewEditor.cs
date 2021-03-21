using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI() {
        FieldOfView FOV = target as FieldOfView;
        Handles.color = Color.white;
        Handles.DrawWireArc(FOV.transform.position, Vector3.up,Vector3.forward, 360f, FOV.ViewRadius);

        Vector3 angleA = FOV.DirectionFromAngle(-FOV.ViewAngle / 2, false);
        Vector3 angleB = FOV.DirectionFromAngle(FOV.ViewAngle / 2, false);

        Handles.DrawLine(FOV.transform.position, FOV.transform.position + (angleA * FOV.ViewRadius));
        Handles.DrawLine(FOV.transform.position, FOV.transform.position + (angleB * FOV.ViewRadius));
    }
}
