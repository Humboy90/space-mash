using NonStandard;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{

    public PanelMovement panel;
    public GameObject bg;
    public TMPro.TMP_Text text;
    public GameObject hud;
    public GameObject mainmenu;

    public TMPro.TMP_InputField waveEndInputField;
    public GameObject winScreen;
    public TMPro.TMP_Text time;
    public TMPro.TMP_Text score;
    public TimeSpeedrun TSScript;

    private void Update()
    {
        if (ImportantVars.Instance.wave == ImportantVars.Instance.gameEndWave && !winScreen.activeInHierarchy)
        {
            LifeCycle.Instance.Pause();
            winScreen.SetActive(true);
            time.text = "Time : " + TSScript.timer;
            score.text = "Score : wip";
        }
    }

    public void TimeSpeedrun()
    {
        StartGameNow();
        ImportantVars.Instance.gameEndWave = int.Parse(waveEndInputField.text);
        
    }

    public void StartGameNow()
    {
        hud.SetActive(true);
        mainmenu.SetActive(false);
        panel.ReanchorToRight();
        text.text = "Resume Game";
        bg.SetActive(false);
        LifeCycle.Instance.Unpause();
    }


    
}
