using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeath : MonoBehaviour
{
    public GameObject[] disableObj;
    public Behaviour[] disableBehavior;
    public ParticleSystem[] playParticles;
    public Collider[] disableCollider;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoActivateTrigger()
    {
        if(disableObj != null)
        {
            System.Array.ForEach(disableObj, p => p.SetActive(false));
        }
        if(disableBehavior != null)
        {
            System.Array.ForEach(disableBehavior, p => p.enabled = false);
        }
        if(playParticles != null)
        {
            System.Array.ForEach(playParticles, p => p.Play());
        }
        if(disableCollider != null)
        {
            System.Array.ForEach(disableCollider, p => p.enabled = false);
            /*System.Array.ForEach(disableCollider, (p) => { p.enabled = false; });
            System.Action<Collider> func = disabletheCollider;//(p) => { p.enabled = false; };
            void disabletheCollider(Collider p)
            {
                p.enabled = false;
            }
            System.Array.ForEach(disableCollider, func);*/
        }
        
    }
}
