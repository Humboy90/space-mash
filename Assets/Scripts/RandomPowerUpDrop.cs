using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPowerUpDrop : MonoBehaviour
{
    public GameObject[] LootTable;

    public float dropChance = 0.25f;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void DropLoot()
    {
        Debug.Log("i am rolling for loot");
        float getlootRoller = Random.value;
        if(getlootRoller < dropChance)
        {
            int weaponRandomRoller = Random.Range(0, LootTable.Length);
            Instantiate(LootTable[weaponRandomRoller], transform.position, transform.rotation);
        }
    }
}
