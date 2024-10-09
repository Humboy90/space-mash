using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModPowerUp : MonoBehaviour
{
    public AdminPowers adpowers;
    
    public NukeTimer text;


    // Start is called before the first frame update
    void Start()
    {
        adpowers = FindObjectOfType<AdminPowers>(true);
        text = FindObjectOfType<NukeTimer>(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void KillAll()
    {
        adpowers.KillAll();
    }
    public void setGMActive()
    {
        text.gameObject.SetActive(true);
    }
    

}
