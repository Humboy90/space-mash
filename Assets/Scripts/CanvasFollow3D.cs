using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFollow3D : MonoBehaviour
{
    public Transform aim3d;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenpos = cam.WorldToScreenPoint(aim3d.transform.position);
        transform.position = screenpos;
    }
}
