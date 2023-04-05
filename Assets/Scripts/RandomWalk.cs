using NonStandard;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : MonoBehaviour
{
    public Vector3 direction;
    public Rigidbody rb;
    public float timer;
    public float walkTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        
        
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            direction = Random.insideUnitSphere;
            //Wires.Make("Direction0").Arrow(transform.position, transform.position + direction, Color.blue);
            direction.y = 0;
            direction = direction.normalized;
            //Wires.Make("Direction").Arrow(transform.position, transform.position + direction, Color.red);

            rb.velocity = direction;
            timer = walkTime;
            
        }
    }
}
