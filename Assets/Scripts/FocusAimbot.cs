using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusAimbot : MonoBehaviour
{

    public GameObject target;
    
    // -5....e..p.5
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<ShipController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = target.transform.position - this.transform.position;
        Vector3 direction = delta.normalized;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
