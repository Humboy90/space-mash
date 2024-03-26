using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int wavelevel => ImportantVars.Instance.wave;
    public Vector3 distanceBetweenEnemies = new Vector3(1.5f, 0, 0);
    public bool waveover;
    public bool aboutToSpawn;
    public int sizeOfGame = 75;
    public float spawnDelay = 3;
    public List<Hitpoints> EnemyWatcher = new List<Hitpoints>();
    public static LevelManager Instance;

    public LevelProgression[] levelProgressions = new LevelProgression[]
    {
        new LevelProgression((1,2,null)),
        new LevelProgression((3,4,null)),
        new LevelProgression((5,6,null), (1,1, null)),
        new LevelProgression((7,8,null)),
        new LevelProgression((1,1,null)),
        new LevelProgression((9,10,null), (1,2, null)),
    };
    // Start is called before the first frame update
    //[[1,2, Robots]]
    //[[3,4, robots]]
    //[[5,6, robots], [1,1, asteroid]]
    //[[7,8 robots]]
    //[[9,10 robots]]
    //[[1,1 boss], [1,2, asteroids]]
    private void OnValidate()
    {
        for(int i =0; i<levelProgressions.Length; i++)
        {
            levelProgressions[i].OnValidate();
        }
        
    }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        AutoExpandLevelProgression(sizeOfGame);
        Debug.Log("spawning level :" + wavelevel);
        SpawnCurrentLevel();
    }

    public void SpawnCurrentLevel()
    {
        
        int levelIndex = wavelevel - 1;
        //if(levelIndex % levelProgressions.Length == 0)
        //{

        //    for (int i = 0; i < levelProgressions.Length; i++)
        //    {
        //        for (int j = 0; j < levelProgressions[i].rosters.Length; j++)
        //        {
        //            levelProgressions[i].rosters[j].minCount += 2;
        //            levelProgressions[i].rosters[j].maxCount += 2;
        //        }
                    
        //    }
        //}

        



        if (levelIndex >= levelProgressions.Length)
        {
            //levelIndex = levelIndex % levelProgressions.Length;
            levelIndex %= levelProgressions.Length;
        }
        //Debug.Log(levelIndex + " " + levelProgressions.Length);
        SpawnWave(levelProgressions[levelIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        if (aboutToSpawn)
        {
            return;
        }

        int counter = 0;
        for (int i = 0; i < EnemyWatcher.Count; i++)
        {
            if(EnemyWatcher[i] == null || EnemyWatcher[i].enabled == false)
            {
                counter++;
            }

        }
        if (counter == EnemyWatcher.Count && EnemyWatcher.Count != 0)
        {
            waveover = true;
        }
        if (waveover == true)
        {
            waveover = false;
            StartCoroutine(waveEnd());
            Debug.Log("wave over");
        }
    }


    public void SpawnWave(LevelProgression levelProgression)
    {
        LevelProgression.Roster r = null;

        for(int i =0; i<levelProgression.rosters.Length; i++)
        {
            r = levelProgression.rosters[i];
            int count = Random.Range(r.minCount, r.maxCount + 1);
            Debug.Log("spawning" + r.subject.name + " " + r.minCount + " " + r.maxCount);
            for(int j =0; j<count; j++)
            {
                GameObject spawnedEnemy = Instantiate(r.subject, distanceBetweenEnemies * j + transform.position, transform.rotation);
                EnemyWatcher.Add(spawnedEnemy.GetComponent<Hitpoints>());
            }
            
        }
        
    }

    public void AutoExpandLevelProgression(int newsize)
    {
        LevelProgression[] newBiggerArray = new LevelProgression[newsize];

        //if(levelIndex % levelProgressions.Length == 0)
        //{

        //    for (int i = 0; i < levelProgressions.Length; i++)
        //    {
        //        for (int j = 0; j < levelProgressions[i].rosters.Length; j++)
        //        {
        //            levelProgressions[i].rosters[j].minCount += 2;
        //            levelProgressions[i].rosters[j].maxCount += 2;
        //        }

        //    }
        //}

        for (int i = 0; i<newBiggerArray.Length; i++)
        {
            //Debug.Log(i + " " + newBiggerArray.Length);
            newBiggerArray[i] = new LevelProgression(levelProgressions[i%levelProgressions.Length]);
        }
        /*
         * 0 0
         * 1 0
         * 2 0
         * 3 0 
         * 4 0
         * 5 0 
         * 6 1
         * 7 1 
         * 8 1
         * 9 1 
         * 10 1
         * 11 1
         * 12 2
         * 13 2
         * 14 2
         * 15 2
         * */
        float enemyCoefficent = 2;
        for (int level = 0; level<newBiggerArray.Length; level++)
        {
            for(int j = 0; j<newBiggerArray[level].rosters.Length; j++)
            {
                newBiggerArray[level].rosters[j].minCount += ((int) enemyCoefficent * level/levelProgressions.Length);
                newBiggerArray[level].rosters[j].maxCount += ((int) enemyCoefficent * level/levelProgressions.Length);
            }
        }


        levelProgressions = newBiggerArray;
    }


    IEnumerator waveEnd()
    {
        waveover = false;
        aboutToSpawn = true;
        yield return new WaitForSeconds(spawnDelay);
        aboutToSpawn = false;
        int waves = ImportantVars.Instance.wave;
        waves += 1;
        ImportantVars.Instance.wave = waves;
        DestroyEnemies();
        SpawnCurrentLevel();

    }

    public void DestroyEnemies()
    {
        for(int i = 0; i < EnemyWatcher.Count; i++)
        {
            if(EnemyWatcher[0] != null)
            {
                Destroy(EnemyWatcher[0].gameObject);
            }
            
            EnemyWatcher.RemoveAt(0);
        }
    }

    
}
