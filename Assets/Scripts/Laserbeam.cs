using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laserbeam : MonoBehaviour
{

    /**
     * TODO
     * When the beam is spawned it should attach to gun
     * If new lazer spawn when there is an older one, destroy new lazer
     * Hold mouse to fire and despawn when released
     * 
     * 
     */



    public LineRenderer lineRend;
    public Collider currentCollision;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(currentCollision != null)
        {
            doLaserLength(currentCollision);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        doLaserLength(other);
        currentCollision = other;
    }

    private void OnTriggerExit(Collider other)
    {
        lineRend.SetPosition(1, Vector3.forward * 1000);
        currentCollision = null;
    }

    public void doLaserLength(Collider other)
    {
        //Debug.Log(other.gameObject);
        Vector3 endpoint = other.transform.position;
        Vector3 startpoint = lineRend.transform.position;
        Vector3 delta = endpoint - startpoint;
        float distance = delta.magnitude;
        endpoint.z = distance;
        endpoint.x = endpoint.y = 0;

        lineRend.SetPosition(1, endpoint);
    }
}
