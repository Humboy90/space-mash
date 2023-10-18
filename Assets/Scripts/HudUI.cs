using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudUI : MonoBehaviour
{

    public Spawner ammo1;
    public Spawner ammo2;
    public TMP_Text score;
    public TMP_Text ammo;
    public TMP_Text wavelabel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score : " + ImportantVars.Instance.score.ToString();
        if (ammo == null || ammo1 == null || ammo2 == null)
        {
            return;
        }
        ammo.text = ammo1.ammoCount.ToString() + " | " + ammo2.ammoCount.ToString();
        wavelabel.text = "Wave : " + ImportantVars.Instance.wave.ToString();
    }
}
