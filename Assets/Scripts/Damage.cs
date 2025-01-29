using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damage : MonoBehaviour
{
    public float damage = 1;
    public int collisions = 0;
    public int maxCollisons = 1;
    public Rigidbody rb;
    public GameObject owner;
    public UnityEvent onHit;
    public Velocity velocity;

    
    public void Start()
    {
        velocity = GetComponent<Velocity>();
        if(owner == null)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        doCollision(collision.gameObject);
    }
    
    public void OnTriggerEnter(Collider other)
    {
        doCollision(other.gameObject);
        if(HealthBar.Instance != null)
        {
            HealthBar.Instance.transform.position = other.transform.position;
            HealthBar.Instance.transform.rotation = Camera.main.transform.rotation;
            HealthBar.Instance.hp = other.GetComponent<Hitpoints>();
        }
        
    }

    public virtual void doCollision(GameObject go)
    {
        Team team = go.GetComponent<Team>();
        if(team != null)
        {
            if (go == owner)
            {
                return;
            }
            if(owner != null)
            {
                if (team.teamID == owner.GetComponent<Team>().teamID)
                {
                    return;
                }
            }
            Hitpoints hp = go.GetComponent<Hitpoints>();
            if (hp == null)
            {
                return;
            }
            else
            {
                collisions += 1;
                hp.hitpoints -= damage;
                hp.hittimer = 1f / 4;
                if (collisions >= maxCollisons && GetComponent<Astroid>() == null)
                {
                    if(rb != null)
                    {
                        rb.velocity = Vector3.zero;
                    }
                    if (GetComponent<BulletBreakable>() != null)
                    {
                        GetComponent<BulletBreakable>().DestroySequence();
                    }
                   
                }
                onHit.Invoke();
            }
        }
        
        
    }

    public void BouncyBullets()
    {
        ChangeDirection();
        maxCollisons += 2;
    }


    public void ChangeDirection()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 nextDir = Random.insideUnitCircle;
        nextDir.z = nextDir.y;
        nextDir.y = 0;
        nextDir = nextDir.normalized;

        rb.velocity = nextDir * velocity.speed;
    }
}
