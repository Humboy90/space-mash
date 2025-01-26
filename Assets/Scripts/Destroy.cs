using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject go;

    public void DestroyThis()
    {
        Destroy(go);
    }

}
