using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float pitch = 0;
    public float yaw = 0;
    public float roll = 0;
    public float mousesens = 5;
    public Transform target;
    public float cameradistance = 10;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ImportantVars.Instance.cameraFreeze == false)
        {
            float mousey = Input.GetAxis("Mouse Y") * mousesens;
            pitch += -mousey;
        }

        else
        {
            pitch = 30;
        }

        float mousex = Input.GetAxis("Mouse X") * mousesens;
        yaw += mousex;
        transform.rotation = Quaternion.Euler(pitch, yaw, roll);
        if (target != null)
        {
            cameradistance += Input.mouseScrollDelta.y;
            Vector3 direction = transform.forward;
            Vector3 offset = direction * cameradistance;
            transform.position = target.position - offset;
        }
    }
}
