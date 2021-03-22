using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour
{
    protected void OnEnable() 
    {
        LevelManager.OnAction += Act;
    }

    protected void OnDisable() 
    {
        LevelManager.OnAction -= Act;
    }

    protected abstract void Act();
}
