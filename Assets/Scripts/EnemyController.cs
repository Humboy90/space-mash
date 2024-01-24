using NonStandard;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<GameObject> listOfEnemies;
    public Vector3 direction;
    public float timer;
    public float walkTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            direction = Random.insideUnitSphere;
            //Wires.Make("Direction0").Arrow(transform.position, transform.position + direction, Color.blue);
            direction.y = 0;
            direction = direction.normalized;
            //Wires.Make("Direction").Arrow(transform.position, transform.position + direction, Color.red);

            //rb.velocity = direction;
            for (int i = 0; i < listOfEnemies.Count; i++)
            {
                listOfEnemies[i].GetComponent<Rigidbody>().velocity = direction;
            }
            timer = walkTime;

        }
    }
}
