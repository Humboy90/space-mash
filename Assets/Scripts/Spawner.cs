using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject athing;
    public KeyCode spawnbutton = KeyCode.Mouse0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(spawnbutton))
        {
            Spawn();
        }
    }

    public GameObject Spawn()
    {
        return Instantiate(athing, transform.position, transform.rotation);
    }
}
