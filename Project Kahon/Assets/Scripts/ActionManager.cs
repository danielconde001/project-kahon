using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionManager : MonoBehaviour
{
    [SerializeField] private uint actionCounter;
    public uint ActionCounter {get {return actionCounter;}}
    
    private void OnEnable() {
        OnAction += () => { actionCounter++; }; 
    }

    public static Action OnAction;

    private void Update() {
          
    }

}
