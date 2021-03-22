using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishLine : MonoBehaviour
{
    public UnityEvent OnFinish;

    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OnFinish.Invoke();   
        }
    }
}
