using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBullets : MonoBehaviour
{
    public GameObject[] bullets;
    private int bulletIndex;
    public Spawner[] spawners;

    public int BulletIndex
    {
        get
        {
            return bulletIndex;
        }
        set
        {
            bulletIndex = value;
            ChangeBullet();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBullet()
    {
        for(int i =0; i<spawners.Length; i++)
        {
            spawners[i].bullet = bullets[bulletIndex];
        }
    }
}
