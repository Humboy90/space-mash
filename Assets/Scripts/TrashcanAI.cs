using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanAI : MonoBehaviour
{
    public Flee flee;
    public Seek seek;
    public Stop stop;
    public Hitpoints hp;

    public Transform target;
    public float rundistance = 10;


    void Start()
    {
        target = ImportantVars.thePlayer.transform;
        flee.target = target;
        seek.target = target;
    }

    // Update is called once per frame
    
    void Update()
    {
        Vector3 delta = target.transform.position - this.transform.position;
        float distance = delta.magnitude;

        //when this distance is 20 greater than the target position stop moving
        // when less than 20 flee 
        // if more than 20 seek.
        if(hp.hitpoints <= 1)
        {
            flee.enabled = false;
            stop.enabled = false;
            seek.enabled = true;
        }
        else if(distance > rundistance)
        {
            flee.enabled = false;
            stop.enabled = true;
        }
        else if(distance < rundistance)
        {
            flee.enabled = true;
            stop.enabled = false;
        }
        
    }
}
