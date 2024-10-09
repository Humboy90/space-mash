using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseShield : MonoBehaviour
{
    public float pulseRate = 1.5f;
    public float radiusPerSecond = 1.2f;
    public float timer;
    public float maxTime = 5;
    public float maxRadius = 5;
    [ContextMenuItem("Test",nameof(TestRadius))]
    public SphereCollider sc;
    public Transform sphereGraphic;
    public float velocity = 1;
    public Hitpoints hp;



    public float Timer
    {
        get => timer;
        set => timer = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<Hitpoints>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * pulseRate;


        if(timer <= maxTime)
        {
            SetShieldRadius(timer);
        }
        else
        {

        }
    }


    public void SetShieldRadius(float radius)
    {
        sphereGraphic.localScale = Vector3.one * (radius*2);
        sc.radius = radius;
    }

    public void TestRadius()
    {
        SetShieldRadius(2);
    }

    public void OnShieldDeath()
    {
        timer = 0;
        hp.triggeredDeath = false;
        hp.hitpoints = hp.maxhitpoints;
    }

}
