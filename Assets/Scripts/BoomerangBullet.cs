using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangBullet : MonoBehaviour
{
    public float speed = 9;
    public float despeed = 3;
    public Rigidbody rb;
    public float timer;
    public Damage dmgScript;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;
        speed -= timer * despeed;
        rb.velocity = transform.forward * speed;
        if(speed <= 0)
        {
            dmgScript.owner = null;
        }
    }
}
