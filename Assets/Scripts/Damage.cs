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
    }

    public void doCollision(GameObject go)
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
                    rb.velocity = Vector3.zero;
                    GetComponent<BulletBreakable>().DestroySequence();
                }
            }
        }
        else
        {
            return;
        }
        
    }
}
