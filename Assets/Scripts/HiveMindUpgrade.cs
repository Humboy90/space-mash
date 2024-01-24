using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveMindUpgrade : EnemyController
{
    public int count = 5;
    public Vector3 delta = new Vector3(1.5f,0,0);
    public GameObject thing;
    // Start is called before the first frame update
    void Start()
    {
        /*
        for (int i =0; i < 100; i++)
        {
            Debug.Log(i + " " + (i % 5));
        }
        */
        listOfEnemies = new List<GameObject>(count);
        for (int i = 0; i<count; i++)
        {
            //if(ImportantVars.Instance.wave % )
            GameObject obj = Instantiate(thing, delta*i, transform.rotation);
            obj.transform.SetParent(this.transform);
            listOfEnemies[i] = obj;
        }
    }

    
}
