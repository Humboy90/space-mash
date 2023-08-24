using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClusters : MonoBehaviour
{
    public enum enemytypes { Normal = 0, Boss = 1}
    public enemytypes[] round = { enemytypes.Normal, enemytypes.Normal, enemytypes.Normal, enemytypes.Normal, enemytypes.Boss };
    public int roundindex;
    public float spawnDelay = 3;
    public GameObject[] enemys;
    public GameObject player;
    public GameObject prefabhm;
    public int distancespawn = 25;
    public bool waveover;
    public bool aboutToSpawn;
    public EnemyController hivemind;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<ShipController>().gameObject;
        SpawnHiveMind();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (aboutToSpawn)
        {
            return;
        }

        int counter = 0;
        for (int i = 0; i < hivemind.listOfEnemies.Length; i++)
        {
            GameObject obj = hivemind.listOfEnemies[i];
            if (obj.GetComponent<Hitpoints>().enabled == false)
            {
                counter++;
            }

        }
        if (counter == hivemind.listOfEnemies.Length && hivemind.listOfEnemies.Length != 0)
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
    IEnumerator waveEnd()
    {
        waveover = false;
        aboutToSpawn = true;
        yield return new WaitForSeconds(spawnDelay);
        aboutToSpawn = false;
        int waves = ImportantVars.Instance.wave;
        waves += 1;
        ImportantVars.Instance.wave = waves;
        if (roundindex == round.Length-1)
        {
            roundindex = 0;
        }
        else
        {
            roundindex += 1;
        }
        

        
        Destroy(hivemind.gameObject);
        SpawnHiveMind();

    }

    public void SpawnHiveMind()
    {
        enemytypes t = round[roundindex];
        int enemyindex = (int)t;
        prefabhm = enemys[enemyindex];
        GameObject thing = Instantiate(prefabhm, player.transform.position + player.transform.forward * distancespawn, player.transform.rotation);
        hivemind = thing.GetComponent<EnemyController>();
    }

    public void Awake()
    {
        //Debug.Log("awake now");
    }
    public void OnDestroy()
    {
        //Debug.Log("destroying now");
    }
}
