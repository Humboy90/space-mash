using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour
{
    public UnityEvent OnPlayerTrigger;
    public float lifetime = 30f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyMeIfImStillAlive());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator destroyMeSoon()
    {
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


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<ShipController>() != null)
        {
            OnPlayerTrigger.Invoke();
        }
    }

    public void SetWeapon(int index)
    {
        ImportantVars.Instance.GetComponent<WeaponChange>().SetWeapon(index);
    }

    public void SetTempWeapon(int index)
    {
        ImportantVars.Instance.GetComponent<WeaponChange>().SetTempWeapon(index);
    }

    public void SetTempAmmoWeapon(int index)
    {
        ImportantVars.Instance.GetComponent<WeaponChange>().SetTempAmmoWeapon(index);
    }

    public void SetLaserBeam()
    {
        ImportantVars.Instance.GetComponent<WeaponChange>().SetLaserBeam();
    }


    public void EmitParticles()
    {
        ParticleController.Instance.transform.position = this.transform.position;
        ParticleController.Instance.Burst(30);
    }
}
