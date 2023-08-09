using NonStandard;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusAimbot : MonoBehaviour
{

    public Transform gun;
    public GameObject target;
    public float aimerror = 0;
    // -5....e..p.5
    // Start is called before the first frame update
    protected virtual void Start()
    {
        target = FindObjectOfType<ShipController>().gameObject;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
        if (isFacingEnemy())
        {
            Vector3 delta = target.transform.position - this.transform.position;
            Vector3 direction = delta.normalized;
            transform.rotation = Quaternion.LookRotation(direction);
            
        }
        //Wires.Make("Lazer" + name).Arrow(gun.position, gun.position + gun.forward * 10, Color.red);
    }

    //refactor plz :L
    public bool isFacingEnemy()
    {
        Vector3 pos = target.transform.position + Random.onUnitSphere * aimerror;
        Vector3 delta = pos - this.transform.position;
        Vector3 direction = delta.normalized;
        float distance = 10;
        if (Physics.SphereCast(gun.position, 0.2f, direction, out RaycastHit hit))
        {
            distance = hit.distance;
            //Wires.Make("Normal" + name).Arrow(hit.point, hit.point + hit.normal, Color.yellow);
            Team teamOfTarget = hit.transform.GetComponent<Team>();
            Velocity vel = hit.transform.GetComponent<Velocity>();
            if(vel != null)
            {
                return false;
            }
            if (teamOfTarget == null)
            {
                //transform.rotation = Quaternion.LookRotation(direction);
                return true;
            }
            bool sameTeam = teamOfTarget.teamID == 1;
            if (sameTeam)
            {
                return false;
            }
            else
            {

                return true;
            }
            
        }
        else
        {
            return false;
        }
        
    }
}
