using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Image HPBAR;
    public Hitpoints hp;
    public static HealthBar Instance;

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


    void Start()
    {
        
    }

    void Update()
    {
        if(hp != null)
        {
            HPBAR.fillAmount = hp.hitpoints / hp.maxhitpoints;
        }
        
    }
}
