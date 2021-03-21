using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour
{
    protected void OnEnable() 
    {
        ActionManager.OnAction += Act;
    }

    protected void OnDisable() 
    {
        ActionManager.OnAction -= Act;
    }

    protected abstract void Act();
}
