using NonStandard;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissle : MonoBehaviour
{
    public AimAssistSpawner aimassist;
    public Rigidbody rb;
    public float maxspeed;
    public float accelerationForce;
    public GameObject babyroid;
    public EnemyController hivemind;
    public Hitpoints hp;
    public float timer = 4;
    public GameObject owner
    {
        get
        {
            return this.GetComponent<Damage>().owner;
        }
    }
   

    public Transform target
    {
        get
        {
            if (aimassist == null || aimassist.enemy == null)
            {
                return null;
            }
            return aimassist.enemy.transform;
        }
    }
    // Make it speed up, slow down if missed the player, split into baby asteroids on death, make a baby asteroid prefab
    // Start is called before the first frame update
    void Start()
    {

        hp = GetComponent<Hitpoints>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            hp.hitpoints -= hp.maxhitpoints;
        }
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

        //Wires.Make("Velocity").Arrow(here, here + rb.velocity, Color.magenta);

        Vector3 steeringVector = there - (here + rb.velocity);

        //Wires.Make("Steering Distance").Line(here + rb.velocity, there, Color.red);

        //Wires.Make("here").Circle(here, Vector3.up, Color.blue);
        //Wires.Make("there").Circle(there, Vector3.up, Color.green);

        Vector3 delta = there - here;

        //Wires.Make("delta").Line(delta, Color.yellow);

        Vector3 directionfromheretothere = delta.normalized;
        Vector3 directionSteeringVector = steeringVector.normalized;
        //Wires.Make("Steering Vector").Line(here, here + directionSteeringVector * accelerationForce, Color.yellow);
        //Wires.Make("direction").Line(delta, Color.cyan);

        Vector3 acceleration = directionSteeringVector * accelerationForce * Time.deltaTime;
        rb.velocity += acceleration;
        float speed = rb.velocity.magnitude;

        if (speed > maxspeed)
        {
            Vector3 maxspeedV3 = rb.velocity.normalized * maxspeed;
            rb.velocity = maxspeedV3;

        }
    }

    public void OnDeathAstroid()
    {
        Vector3 here = this.transform.position;
        Quaternion parentRotation = this.transform.rotation;
        GameObject babyroidInstance = Instantiate(babyroid, here, parentRotation);
    }
    public void DestroyOwnGameOBJ()
    {
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Team>().teamID != owner.GetComponent<Team>().teamID)
        {
            hp.hitpoints -= hp.maxhitpoints;
        }
        
    }

}

