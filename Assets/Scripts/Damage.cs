using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 1;


    public void OnCollisionEnter(Collision collision)
    {
        Hitpoints hp = collision.gameObject.GetComponent<Hitpoints>();
        if(hp == null)
        {
            return;
        }
        else
        {
            hp.hitpoints -= damage;
            hp.hittimer = 1f / 4;           
        }
    }
}
