using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenHP : MonoBehaviour
{

    public Hitpoints hp;

    public float timer;
    public float maxTime = 4f;
    public float delayOfRegen = -4f;

    void Start()
    {
        
    }

    void Update()
    {
        


        if(hp.hitpoints < hp.maxhitpoints && hp.hitpoints > 0)
        {
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                hp.hitpoints += 1;
                timer = 0;
            }
        }
        
    }


    public void OnCollisionEnter(Collision collision)
    {
        timer = delayOfRegen;
    }

}
