using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public GameObject ally;
    public GameObject athing;
    public int ammoCount;
    public int maxammo = 6;
    public KeyCode spawnbutton = KeyCode.Mouse0;
    public float timer = 1.5f;
    [Tooltip("Duration Between Shots")]
    public float cd;
    [Tooltip("Reload time")]
    public float rlttime;
    public Transform aim;
    public UnityEvent_Float onTimerUpdate;

    [System.Serializable] public class UnityEvent_Float : UnityEvent<float> { }

    // Start is called before the first frame update
    void Start()
    {
        ReloadNow();
    }
    public void ReloadNow()
    {
        ammoCount = maxammo;
    }
    // Update is called once per frame
    // if we look arnt looking at enemy dont shoot, if player shoot
    void Update()
    {
        if(Time.timeScale == 0)
        {

            //Debug.Log("paused");
            return;
            
        }
        if (aim != null)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.SphereCast(ray, 0.125f, out RaycastHit hit))
            {
                aim.position = hit.transform.position + hit.transform.forward * 2;
                aim.rotation = hit.transform.rotation;
            }

            else
            {
                aim.position = ray.GetPoint(10);
                aim.rotation = transform.rotation;
            }
        }

        if (ammoCount == 0)
        {
            timer = rlttime;
            ReloadNow();
        }

        timer -= Time.deltaTime;
        onTimerUpdate.Invoke(1-timer/rlttime);
        if (Input.GetKeyDown(spawnbutton))
        {
            
            if (ammoCount >= 1 && timer <= 0)
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
            timer = rlttime;
            ReloadNow();
        }

    }

    public GameObject Spawn()
    {
        GameObject thing = Instantiate(athing, transform.position, transform.rotation);
        Damage dmg = thing.GetComponentInChildren<Damage>();
        if(dmg != null)
        {
            dmg.owner = ally;
        }
        return thing;
    }
}
