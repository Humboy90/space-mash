using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ally;
    public GameObject athing;
    public int ammoCount = 6;
    public KeyCode spawnbutton = KeyCode.Mouse0;
    public float timer = 1.5f;
    [Tooltip("Duration Between Shots")]
    public float cd;
    [Tooltip("Reload time")]
    public float rlttime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // if we look arnt looking at enemy dont shoot, if player shoot
    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetKeyDown(spawnbutton))
        {
            if(ammoCount >= 1 && timer <= 0)
            {
                Spawn();
                ammoCount -= 1;
                timer = cd;
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
                timer = rlttime;
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
