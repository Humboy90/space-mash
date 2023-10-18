using NonStandard;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAssistSpawner : MonoBehaviour
{
    public GameObject enemy;
    public Team[] teamMembers;
    public int enemyTeamID = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy = FindClosestEnemy();
        Wires.Make("enemyTracker").Arrow(transform.position, enemy.transform.position, Color.blue);
        //this.transform.LookAt(enemy.transform);
        Vector3 delta = enemy.transform.position - transform.position;
        Vector3 direction = delta.normalized;
        Quaternion desiredRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, 30 * Time.deltaTime);
    }


    public GameObject FindClosestEnemy()
    {
        teamMembers = FindObjectsOfType<Team>();
        float closestPos = float.PositiveInfinity;
        int closestEnemyID = 0;

        for (int i = 0; i < teamMembers.Length; i++)
        {
            if (teamMembers[i].teamID == enemyTeamID && teamMembers[i].GetComponent<Hitpoints>().enabled)
            {
                if(Vector3.Distance(this.transform.position, teamMembers[i].transform.position) < closestPos)
                {
                    closestPos = Vector3.Distance(this.transform.position, teamMembers[i].transform.position);
                    closestEnemyID = i;
                }
                

            }

        }
        return teamMembers[closestEnemyID].gameObject;
    }
}
