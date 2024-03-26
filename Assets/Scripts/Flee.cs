using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{
    public Transform target;
    public Rigidbody rb;
    public float accelerationForce = 3;
    public float maxspeed = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 here = this.transform.position;
        if (target == null)
        {
            return;
        }
        Vector3 there = target.transform.position;
        Rigidbody targetrb = target.gameObject.GetComponent<Rigidbody>();
        if (targetrb != null)
        {
            there += targetrb.velocity;
        }



        Vector3 steeringVector = there - (here + rb.velocity);
        Vector3 delta = there - here;
        Vector3 directionfromheretothere = delta.normalized;
        Vector3 directionSteeringVector = steeringVector.normalized;

        Vector3 acceleration = directionSteeringVector * accelerationForce * Time.deltaTime;
        rb.velocity += -acceleration;
        float speed = rb.velocity.magnitude;

        if (speed > maxspeed)
        {
            Vector3 maxspeedV3 = rb.velocity.normalized * maxspeed;
            rb.velocity = maxspeedV3;

        }
    }
}
