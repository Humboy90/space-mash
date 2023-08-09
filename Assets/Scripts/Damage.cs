using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 1;
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
            if (team.teamID == owner.GetComponent<Team>().teamID)
            {
                return;
            }
            Hitpoints hp = go.GetComponent<Hitpoints>();
            if (hp == null)
            {
                return;
            }
            else
            {
                hp.hitpoints -= damage;
                hp.hittimer = 1f / 4;
            }
        }
        else
        {
            return;
        }
        
    }
}
