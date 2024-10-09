using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageBigBullet : Damage
{

    public override void doCollision(GameObject go)
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
            bool isBullet = go.gameObject.GetComponent<BulletBreakable>();
            Debug.Log(isBullet);
            if (hp == null || isBullet)
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
                    Debug.Log(go);
                }
                onHit.Invoke();
            }
        }
        else
        {
            return;
        }
        

       
    }



}
