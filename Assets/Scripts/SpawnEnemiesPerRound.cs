using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesPerRound : MonoBehaviour
{
    public countVarModifier countModifier;
    public int count = 5;
    public int distancespawn = 25;
    public Vector3 delta = new Vector3(1.5f, 0, 0);
    public GameObject thing;
    public EnemyController hivemind;
    public bool waveover = false;
    public GameObject prefabhm;
    public SpawnClusters spawncluster;
    public int wavepause;
    
    public enum countVarModifier
    {
        none,enemies,boss
    }
    // Start is called before the first frame update
    void Start()
    {

        // Separate the normal enemy counter from boss counter because bosses dont spawn every round and are stronger
        
        if(countModifier == countVarModifier.enemies)
        {
            int num = Random.Range(1, 3);
            count = ImportantVars.Instance.enemycount;
            count += num;
            ImportantVars.Instance.enemycount = count;
        }
        else if(countModifier == countVarModifier.boss)
        {
            int num = Random.Range(1, 3);
            count = ImportantVars.Instance.bosscount;
            count += num;
            ImportantVars.Instance.bosscount = count;
        }

        if (hivemind == null)
        {
            hivemind = GetComponent<EnemyController>();
        }
        hivemind.listOfEnemies = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(thing, delta * i + transform.position, transform.rotation);
            obj.transform.SetParent(this.transform);
            hivemind.listOfEnemies[i] = obj;
        }
    }

    
}
