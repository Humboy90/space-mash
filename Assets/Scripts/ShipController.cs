using NonStandard;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public int rotationspeed = 360;
    public int movespeed = 5;
    public ParticleSystem thruster;
    public Transform cam;
    private bool cursorLock = false;
    public GameObject shipGraphic;
    public CustimizeClass custimizer;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        //Debug.Log(string.Join(",", (object[])GetComponentsInChildren<Renderer>()));
        custimizer.LoadShip();
        //Debug.Log(string.Join(",",(object[])GetComponentsInChildren<Renderer>()));
        GetComponent<Hitpoints>().RecalculateRender();
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

        Vector3 moveDirection = Vector3.zero;


        if (Input.GetKey(KeyCode.A))
        {
            //transform.Rotate(0, -1 * rotationspeed * Time.deltaTime, 0);
            //transform.position += -transform.right * movespeed * Time.deltaTime;
            moveDirection += -transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.Rotate(0, 1 * rotationspeed * Time.deltaTime, 0);
            //transform.position += transform.right * movespeed * Time.deltaTime;
            moveDirection += transform.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (!thruster.isPlaying)
            {
                thruster.Play();
            }
            //transform.position += transform.forward * movespeed * Time.deltaTime;
            moveDirection += transform.forward;
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
            //transform.position -= transform.forward * movespeed * Time.deltaTime;
            moveDirection += -transform.forward;
        }

        rb.velocity = moveDirection * movespeed;
        
    }
    private void LateUpdate()
    {
        Vector3 forward = cam.transform.forward;
        //Wires.Make("Plane").Circle(transform.position, Vector3.up, Color.yellow, 5);
        //Wires.Make("Plane Normal").Arrow(transform.position, transform.position + Vector3.up * 3, Color.yellow);
        //Wires.Make("Ship Forward").Arrow(transform.position, transform.position + forward * 3, Color.blue);
        float alignment = Vector3.Dot(Vector3.up, forward);
        Vector3 alignmentDelta = Vector3.up * alignment;
        //Wires.Make("Ship Alignment").Arrow(transform.position + forward * 3, transform.position + forward * 3 - alignmentDelta * 3, Color.green);
        Vector3 origin = transform.position;
        Vector3 endpoint = transform.position + forward * 3 - alignmentDelta * 3;
        Vector3 delta = endpoint - origin;
        float magnitude = delta.magnitude;//Mathf.Sqrt(delta.x * delta.x + delta.y * delta.y + delta.z * delta.z);
        if (magnitude != 0)
        {
            Vector3 direction = delta / magnitude;//new Vector3(delta.x / magnitude, delta.y / magnitude, delta.z / magnitude);
            //Wires.Make("Delta").Arrow(origin, origin + delta, Color.magenta);
            //Wires.Make("Direction").Arrow(origin, origin + direction * 3, Color.cyan, 0.25f);
            Quaternion planeForward = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = planeForward;
        }
        
    }
}
