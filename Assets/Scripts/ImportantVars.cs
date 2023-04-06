using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ImportantVars : MonoBehaviour
{
    public int score;
    public Spawner ammo1;
    public Spawner ammo2;
    public TMP_Text text;
    public TMP_Text text2;
    public static ImportantVars Instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score : " + score.ToString();
        text2.text = ammo1.ammoCount.ToString() + " | " + ammo2.ammoCount.ToString();
    }

    private void Awake()
    {
        Instance = this;
    }
}
