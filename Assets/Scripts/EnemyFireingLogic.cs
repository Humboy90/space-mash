using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyFireingLogic : MonoBehaviour
{
    // determine if this is an enemy that if its looking at its friend, no shoot

    public FocusAimbot fa;
    public Spawner spawn;
    public float timer = 3f;
    public float cooldown = 3f;
    public float reloadtime = 6f;
    public Image reloadingimg;

    public UnityEvent_Float onTimerUpdate;

    [System.Serializable] public class UnityEvent_Float : UnityEvent<float> { }

    private void Start()
    {
        
        if(reloadingimg != null)
        {
            reloadingimg.enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        onTimerUpdate.Invoke(1 - timer / reloadtime);
        if (timer <= 0)
        {
            if(spawn.ammoCount > 0)
            {
                if(reloadingimg != null)
                {
                    reloadingimg.enabled = false;
                }
                
                if (fa.isFacingEnemy())
                {
                    Debug.Log("im shooting");
                    spawn.Spawn();
                }
                else
                {
                    return;
                }
                timer = cooldown;
                spawn.ammoCount -= 1;
            }
            else
            {
                reloadingimg.enabled = true;
                spawn.ammoCount = spawn.maxammo;
                timer = reloadtime;
            }
            
        }
        
        
    }
}
