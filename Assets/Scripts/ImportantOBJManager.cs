using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportantOBJManager : MonoBehaviour
{
    public GameObject prefab;
    public GameObject instantiated;

    public void Instantiate()
    {
        instantiated = Instantiate(prefab);
    }
    public void Release()
    {
        if(instantiated == null)
        {
            return;
        }
        Destroy(instantiated);
    }
}
