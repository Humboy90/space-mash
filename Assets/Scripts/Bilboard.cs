using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilboard : MonoBehaviour
{
    public Transform mycamera;
    // Start is called before the first frame update
    void Start()
    {
        mycamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = mycamera.rotation;
    }
}
