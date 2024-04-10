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
    [SerializeField]
    private int maxAmmo = 6;
    [SerializeField]
    private int speed = 6;
    public List<Spawner> spawnersControlledByMaxAmmo;
    public static ImportantVars Instance;
    public HudUI hud;
    public TimeSpeedrun tsscript;
    public static ShipController thePlayer => GameObject.FindObjectOfType<ShipController>(true);

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

    public float MaxAmmo
    {
        get
        {
            return maxAmmo;
        }
        set
        {
            maxAmmo = (int) value;
            for (int i = 0; i < spawnersControlledByMaxAmmo.Count; i++)
            {
                spawnersControlledByMaxAmmo[i].maxammo = maxAmmo;
            }
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = (int)value;
            thePlayer.movespeed = speed;
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

    public void IncreaseAmmo(int addAmmo)
    {
        MaxAmmo += addAmmo;
    }

}
