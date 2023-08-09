using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminPowers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillAll()
    {
        //GameObject.FindObjectsOfTypeAll(typeof(Hitpoints));
        Hitpoints[] hps = GameObject.FindObjectsOfType<Hitpoints>();
        //HiveMindSpawner hivespawner = GameObject.FindObjectOfType<HiveMindSpawner>();
        for (int i =0; i < hps.Length; i++)
        {
            hps[i].hitpoints = 0;
        }
    }
}
