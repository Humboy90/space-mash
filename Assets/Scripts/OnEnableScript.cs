using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableScript : MonoBehaviour
{
    public UnityEvent onEnable;
    public UnityEvent onDisable;
    private void OnEnable()
    {
        //Debug.Log("im funny :)" + name);
        onEnable.Invoke();

    }
    private void OnDisable()
    {
        onDisable.Invoke();
    }
}
