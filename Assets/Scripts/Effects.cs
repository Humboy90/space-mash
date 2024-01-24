using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public static Effects Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StunEffect(MonoBehaviour mb, float timer)
    {
        StartCoroutine(TemporaryDisable());
        IEnumerator TemporaryDisable()
        {
            mb.enabled = false;
            yield return new WaitForSeconds(timer);
            if(mb != null)
            {
                mb.enabled = true;
            }
        }
    }

    public void StunEffectObject(MonoBehaviour mb, float timer)
    {
        GameObject stun = new GameObject("Stun " + mb.name);
        StunEffect effect = stun.AddComponent<StunEffect>();
        effect.target = mb;
        effect.timer = timer;
        stun.transform.SetParent(transform);
    }
}
