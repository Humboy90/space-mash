using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ImportantVars : MonoBehaviour
{
    public int score;
    public int wave = 1;
    public static bool timespeedruntoggle;
    public int gameEndWave = 5;
    public int enemycount;
    public int bosscount;
    public static ImportantVars Instance;
    public HudUI hud;
    public TimeSpeedrun tsscript;

    public int EnemyCount
    {
        get
        {
            return enemycount;
        }
        set
        {
            enemycount = value;
        }
    }

    

    

    public void WaveEndAsString(string str)
    {
        gameEndWave = int.Parse(str);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void NewGame()
    {
        score = 0;
        wave = 1;
        timespeedruntoggle = false;
        enemycount = 0;
        bosscount = 0;
        tsscript.timer = 0f;
        hud.ammo1.ReloadNow();
        hud.ammo2.ReloadNow();
    }
}
