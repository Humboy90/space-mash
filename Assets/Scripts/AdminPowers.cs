using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminPowers : MonoBehaviour
{
    public TMPro.TMP_InputField inputField;

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

    public void WaveSelect()
    {
        KillAll();
        LevelManager lm = FindObjectOfType<LevelManager>();
        ImportantVars.Instance.wave = int.Parse(inputField.text);
        lm.SpawnCurrentLevel();


    }
}
