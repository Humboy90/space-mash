using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    
    private static DontDestroy Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        Instance = this;
    }

    public static void DoThisSoon(System.Action thingtodo, float whentodo)
    {
        Debug.Log("going to do a thing" + whentodo);
        IEnumerator DoThisSoon_inner()
        {
            Debug.Log("entry point");
            yield return null;//new WaitForSeconds(whentodo);
            Debug.Log("finished waiting");
            thingtodo.Invoke();
            Debug.Log("done");
        }
        Instance.StartCoroutine(DoThisSoon_inner());
    }

}
