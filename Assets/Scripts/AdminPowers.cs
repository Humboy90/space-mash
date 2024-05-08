using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminPowers : MonoBehaviour
{
    public TMPro.TMP_InputField inputField;
    public GameObject player;
    public static AdminPowers Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
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
            if(hps[i].gameObject.GetComponent<ShipController>() == null)
            {
                hps[i].hitpoints = 0;
            }
            ;
        }
    }

    public void Die1HP()
    {
        player.GetComponent<Hitpoints>().hitpoints -= 1;
    }

    public void WaveSelect()
    {
        KillAll();
        LevelManager lm = FindObjectOfType<LevelManager>();
        ImportantVars.Instance.wave = int.Parse(inputField.text);
        lm.SpawnCurrentLevel();


    }
}
