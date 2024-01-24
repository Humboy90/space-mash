using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBreakable : MonoBehaviour
{
    public float lifetime = 3;
    void Start()
    {
        //Destroy(gameObject, 3);
        StartCoroutine(destroyMeIfImStillAlive());
    }

    IEnumerator destroyMeSoon()
    {        
        GetComponent<Renderer>().enabled = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Collider>().enabled = false;
        //GetComponent<TrailRenderer>().time = 0;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    IEnumerator destroyMeIfImStillAlive()
    {
        yield return new WaitForSeconds(lifetime);
        if (gameObject == null)
        {
            yield break;
        }

        StartCoroutine(destroyMeSoon());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Team>() == null)
        {
            return;
        }
        if(collision.gameObject.GetComponent<Team>().teamID != this.GetComponent<Team>().teamID)
        {
            DestroySequence();
        }
        
    }

    public void DestroySequence()
    {
        StartCoroutine(destroyMeSoon());
    }
}
