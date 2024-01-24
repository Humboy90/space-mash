using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int wavelevel => ImportantVars.Instance.wave;
    public Vector3 distanceBetweenEnemies = new Vector3(1.5f, 0, 0);
    public bool waveover;
    public bool aboutToSpawn;
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
        Debug.Log("spawning level :" + wavelevel);
        SpawnCurrentLevel();
    }

    public void SpawnCurrentLevel()
    {
        
        int levelIndex = wavelevel - 1;
        if(levelIndex % levelProgressions.Length == 0)
        {

            for (int i = 0; i < levelProgressions.Length; i++)
            {
                for (int j = 0; j < levelProgressions[i].rosters.Length; j++)
                {
                    levelProgressions[i].rosters[j].minCount += 2;
                    levelProgressions[i].rosters[j].maxCount += 2;
                }
                    
            }
        }
        if (levelIndex >= levelProgressions.Length)
        {
            //levelIndex = levelIndex % levelProgressions.Length;
            levelIndex %= levelProgressions.Length;
        }
        Debug.Log(levelIndex + " " + levelProgressions.Length);
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
            for(int j =0; j<count; j++)
            {
                GameObject spawnedEnemy = Instantiate(r.subject, distanceBetweenEnemies * j + transform.position, transform.rotation);
                EnemyWatcher.Add(spawnedEnemy.GetComponent<Hitpoints>());
            }
            
        }
        
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
