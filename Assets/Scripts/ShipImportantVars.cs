using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipImportantVars : MonoBehaviour
{
    
    public float damageTier = 0;
    public float rangeTier = 0;
    public float speedTier = 0;

    public TMPro.TMP_Text text;
    private float displayedHP;
    public Hitpoints hp;
    public void Start()
    {
        hp = GetComponent<Hitpoints>();
        UpdateHP();
        hp.onHPchange.AddListener(UpdateHP);
    }
    

    public void UpdateHP()
    {
        if (hp.hitpoints < displayedHP && hp.hitpoints > 0)
        {
            ImportantVars.Instance.score -= (int)(100 * (displayedHP - hp.hitpoints));
        }

        if (hp.hitpoints != displayedHP)
        {
            displayedHP = hp.hitpoints;
            text.text = "HP : " + hp.hitpoints.ToString();
        }

        
    }

    public void UpdateScore(TMPro.TMP_Text text)
    {
        text.text = "Score : " + ImportantVars.Instance.score.ToString();
    }

    

}
