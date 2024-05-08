using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    public float speed = 9;
    // Start is called before the first frame update
    void Start()
    {
        Damage dmg = GetComponent<Damage>();
        ShipImportantVars shipIV = dmg.owner.GetComponent<ShipImportantVars>();
        if (shipIV != null)
        {
            speed = GetComponent<DamageUpgrade>().speedTier[(int)shipIV.speedTier];
        }

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
