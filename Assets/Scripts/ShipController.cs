using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public int rotationspeed = 360;
    public int movespeed = 5;
    public ParticleSystem thruster;
    private bool cursorLock = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Insert))
        {
            if(cursorLock == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
                cursorLock = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                cursorLock = false;
            }
            
        }


        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1 * rotationspeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1 * rotationspeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (!thruster.isPlaying)
            {
                thruster.Play();
            }            
            transform.position += transform.forward * movespeed * Time.deltaTime;
        }
        else
        {
            if (thruster.isPlaying)
            {
                thruster.Stop();
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * movespeed * Time.deltaTime;
        }
    }
}
