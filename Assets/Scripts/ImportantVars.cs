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
    [SerializeField]
    private int health = 3;
    [SerializeField]
    private float firecd = 0.7f;
    [SerializeField]
    private float regenTime = 4f;
    [SerializeField]
    private int damageTier = 0;
    [SerializeField]
    private float rangeTier = 0;
    [SerializeField]
    private float speedTier = 0;
    public List<Spawner> spawnersControlledByMaxAmmo;
    public static ImportantVars Instance;
    public HudUI hud;
    public TimeSpeedrun tsscript;
    public static ShipController thePlayer => GameObject.FindObjectOfType<ShipController>(true);

    public bool cameraFreeze = true;

    

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

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = (int)value;
            thePlayer.GetComponent<Hitpoints>().maxhitpoints = health;

        }
    }

    public float Firecd
    {
        get
        {
            return firecd;
        }
        set
        {
            firecd = value;
            for (int i = 0; i < spawnersControlledByMaxAmmo.Count; i++)
            {
                spawnersControlledByMaxAmmo[i].cd = firecd;
            }

        }
    }

    public float RegenTime
    {
        get
        {
            return regenTime;
        }
        set
        {
            regenTime = value;
            thePlayer.GetComponent<RegenHP>().maxTime = regenTime;

        }
    }
    public float DamageTier
    {
        get
        {
            return damageTier;
        }
        set
        {
            damageTier = (int)value;
            thePlayer.GetComponent<ShipImportantVars>().damageTier = damageTier;

        }
    }

    public float RangeTier
    {
        get
        {
            return rangeTier;
        }
        set
        {
            rangeTier = (int)value;
            thePlayer.GetComponent<ShipImportantVars>().rangeTier = rangeTier;

        }
    }

    public float SpeedTier
    {
        get
        {
            return speedTier;
        }
        set
        {
            speedTier = (int)value;
            thePlayer.GetComponent<ShipImportantVars>().speedTier = speedTier;

        }
    }

    public void ToggleCameraFreeze()
    {
        if (cameraFreeze)
        {
            cameraFreeze = false;
        }
        else
        {
            cameraFreeze = true;
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
