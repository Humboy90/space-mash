using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftPosition : MonoBehaviour
{
    public float xVal = -255f;
    // Determines if the stat menu is out or hidden
    public bool statMenuIsHidden = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MovePos()
    {
        if (statMenuIsHidden)
        {
            transform.position = new Vector3 (0, transform.position.y, transform.position.z);
            statMenuIsHidden = false;
        }
        else
        {
            transform.position = new Vector3 (xVal, transform.position.y, transform.position.z);
            statMenuIsHidden = true;
        }
        
    }

}
