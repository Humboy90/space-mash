using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGun : Damage
{
    //public float damage = 1.5f;
    public float radius = 1f / 32;
    public float stuntimer = .5f;
    public LineRenderer line;
    public float exitTime = .5f;
    public ShipController player;

    void Start()
    {
        player = owner.GetComponent<ShipController>();
        RailgunShoot();
        
    }


    void Update()
    {
        //if(player.enabled == false)
        //{
        //    stuntimer -= Time.deltaTime;
        //    if(stuntimer <= 0)
        //    {
        //        player.enabled = true;
        //    }
        //}

        SetWidth(exitTime);
        exitTime -= Time.deltaTime;
        if(exitTime < 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetWidth(float w) 
    {
        //line.SetWidth(timer, timer);
        //AnimationCurve widthCurve = line.widthCurve;
        //widthCurve.keys[0].value = w;
        line.widthCurve = AnimationCurve.Linear(0, w, 1, w);
        //line.widthCurve.keys[1].value = w;
    }

    public void RailgunShoot()
    {
        //player.enabled = false;
        Effects.Instance.StunEffectObject(player, stuntimer);
        Ray ray = new Ray(transform.position, transform.forward);
        if(Physics.SphereCast(ray, radius, out RaycastHit hit) == true)
        {
            Hitpoints hp = hit.transform.GetComponent<Hitpoints>();
            if(hp != null)
            {
                Debug.Log("i hit " + hit.transform.gameObject);
                hp.hitpoints -= damage;
                hp.hittimer = 1f / 4;
                line.SetPositions(new Vector3[] { ray.origin, hit.point });
            }
        }
        else
        {
            line.SetPositions(new Vector3[] { ray.origin, ray.GetPoint(1000) });
        }

    }
     
}
