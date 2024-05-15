using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    public Spawner gunLeft;
    public Spawner gunRight;
    public GameObject laser1;
    public GameObject laser2;

    public float timer;
    public float duration = 3;

    //public bool tempAmmoOn;

    public GameObject[] weapons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                SetWeapon(0);
            }
        }
        

        //if (!tempAmmoOn)
        //{
        //    SetWeapon(0);
        //}
    }

    public void SetWeapon(int index)
    {
        laser1.SetActive(false);
        laser2.SetActive(false);
        gunLeft.enabled = true;
        gunRight.enabled = true;
        if (gunLeft.bullet == weapons[index])
        {
            return;
        }
        Debug.Log("changed bullet to " + weapons[index]);
        gunLeft.bullet = weapons[index];
        gunRight.bullet = weapons[index];
    }

    public void SetTempWeapon(int index)
    {
        laser1.SetActive(false);
        laser2.SetActive(false);
        gunLeft.enabled = true;
        gunRight.enabled = true;
        gunLeft.bullet = weapons[index];
        gunRight.bullet = weapons[index];
        timer = duration;
    }

    public void SetTempAmmoWeapon(int index)
    {
        laser1.SetActive(false);
        laser2.SetActive(false);
        gunLeft.enabled = true;
        gunRight.enabled = true;
        gunLeft.bullet = weapons[index];
        Debug.Log("changed bullet to " + weapons[index]);
        gunRight.bullet = weapons[index];
        //tempAmmoOn = true;
        gunLeft.ReloadNow();
        gunRight.ReloadNow();

    }
    public void SetLaserBeam()
    {
        gunLeft.enabled = false;
        gunRight.enabled = false;
        laser1.SetActive(true);
        laser2.SetActive(true);

    }
}
