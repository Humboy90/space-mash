using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage = 1;
    public int collisions = 0;
    public int maxCollisons = 1;
    public Rigidbody rb;
    public GameObject owner;

    public void OnCollisionEnter(Collision collision)
    {
        doCollision(collision.gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        doCollision(other.gameObject);
        HealthBar.Instance.transform.position = other.transform.position;
        HealthBar.Instance.transform.rotation = Camera.main.transform.rotation;
        HealthBar.Instance.hp = other.GetComponent<Hitpoints>();
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
            }
        }
        
        
    }
}
