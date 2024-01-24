using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunEffect : MonoBehaviour
{
    public float timer;
    public MonoBehaviour target;

    void Start()
    {
        target.enabled = false;    
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer > 0)
        {
            return;
        }
        if(target != null)
        {
            target.enabled = true;
        }
        Destroy(gameObject);
    }
}
