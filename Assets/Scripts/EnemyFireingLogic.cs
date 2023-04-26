using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireingLogic : MonoBehaviour
{
    // determine if this is an enemy that if its looking at its friend, no shoot

    public FocusAimbot fa;
    public Spawner spawn;
    public float timer = 3f;

    

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            if(spawn.ammoCount > 0)
            {
                if (fa.isFacingEnemy())
                {
                    spawn.Spawn();
                }
                else
                {
                    return;
                }
                timer = 3f;
                spawn.ammoCount -= 1;
            }
            else
            {
                spawn.ammoCount = 6;
                timer = 6f;
            }
            
        }
        
        
    }
}
