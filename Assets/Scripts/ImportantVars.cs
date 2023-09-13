using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ImportantVars : MonoBehaviour
{
    public int score;
    public int wave = 1;
    public int gameEndWave = 5;
    public int enemycount;
    public int bosscount;
    public Spawner ammo1;
    public Spawner ammo2;
    public TMP_Text text;
    public TMP_Text text2;
    public TMP_Text wavelabel;
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
        wavelabel.text = "Wave : " + wave.ToString();



    }

    private void Awake()
    {
        Instance = this;
    }
}
