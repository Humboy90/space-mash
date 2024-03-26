using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    public float decelerationPower = 1;
    public Rigidbody rb;
    public Vector3 velocity;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity = rb.velocity;
        Vector3 deceleration = -velocity.normalized;
        rb.velocity += deceleration * Time.deltaTime * decelerationPower;
        
    }
}
