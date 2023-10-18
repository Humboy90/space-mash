using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeSpeedrun : MonoBehaviour
{
    public GameObject scoreUI;
    public GameObject timerUI;

    public float timer;
    void Start()
    {
        
    }
    void Update()
    {
        timer += Time.deltaTime;
        timerUI.GetComponent<TMP_Text>().text = "Time : " + timer.ToString("#.0");
    }

    public void TimeSpeedrunUIChange()
    {
        timerUI.SetActive(true);
        ImportantVars.timespeedruntoggle = true;
    }

    public void LeaveTimeSpeedrun()
    {
        timerUI.SetActive(false);
        ImportantVars.timespeedruntoggle = false;
    }
}
