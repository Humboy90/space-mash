using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyDebug : MonoBehaviour
{
    public string message;
    void OnDestroy()
    {
        Debug.Log(message);
    }

    private void OnDisable()
    {
        Debug.Log(message);
    }
}
