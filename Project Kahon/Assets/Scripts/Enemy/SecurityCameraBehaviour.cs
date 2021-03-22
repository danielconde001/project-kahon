using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SecurityCameraBehaviour : EnemyBehaviour
{
    [SerializeField] bool activateOnStart;

    MeshRenderer viewMesh;
    FieldOfView fieldOfView;

    protected void Awake() {
        viewMesh = transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>();
        fieldOfView = transform.GetChild(0).GetComponent<FieldOfView>();
    }

    protected void Start() {
        if (!activateOnStart) {
            viewMesh.enabled = false;
            fieldOfView.enabled = false;
        }
    }

    protected override void Act()
    {
        ToggleCamera();
    }

    protected virtual void ToggleCamera()
    {
        viewMesh.enabled = !viewMesh.enabled;
        fieldOfView.enabled = !fieldOfView.enabled;
    }
}
