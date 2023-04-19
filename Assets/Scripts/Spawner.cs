using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ally;
    public GameObject athing;
    public int ammoCount = 6;
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
            if(ammoCount >= 1)
            {
                Spawn();
                ammoCount -= 1;
            }
            else
            {
                Debug.Log("You need ammo!");
            }
            
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(ammoCount == 0)
            {
                ammoCount = 6;
            }
            else
            {
                return;
            }
        }

    }

    public GameObject Spawn()
    {
        GameObject thing = Instantiate(athing, transform.position, transform.rotation);
        Damage dmg = thing.GetComponentInChildren<Damage>();
        if(dmg != null)
        {
            dmg.ally = ally;
        }
        return thing;
    }
}
