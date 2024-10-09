using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeTimer : MonoBehaviour
{
    
    public float timetowait = 3;
    public TMPro.TMP_Text text;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        Debug.Log("start");
        AdminPowers apowers = FindObjectOfType<AdminPowers>(true);
       
        for (int i = 0; i < timetowait * 4; i++)
        {
            text.enabled = !text.enabled;
            yield return new WaitForSeconds(1f/4);
        }

        apowers.KillAll();
        text.enabled = false;

        //Debug.Log("guh");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
