using NonStandard;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{

    public PanelMovement panel;
    public GameObject bg;
    public TMPro.TMP_Text text;
    public GameObject hud;
    public GameObject statTree;
    public GameObject mainmenu;
    public GameObject defaultBullet;
    public MultiStats multiStat;

    public TMPro.TMP_InputField waveEndInputField;
    public GameObject winScreen;
    public TMPro.TMP_Text time;
    public TMPro.TMP_Text score;
    public TimeSpeedrun TSScript;
    public bool timespeedruntoggle;
    public bool spawnManagerSpawned;

    public GameObject startbutton;
    public GameObject resumebutton;
    public GameObject playerobj;
    public ImportantOBJManager importantobjm;
    public HudUI hudUI;

    public void Start()
    {
        hudUI = GetComponent<HudUI>();
    }

    private void Update()
    {
        //Debug.Log($"{ImportantVars.Instance.wave} {ImportantVars.Instance.gameEndWave} {winScreen.activeInHierarchy} {timespeedruntoggle}");
        if (ImportantVars.Instance.wave == ImportantVars.Instance.gameEndWave && !winScreen.activeInHierarchy && timespeedruntoggle)
        {
            LifeCycle.Instance.Pause();
            Debug.Log("im working to pause");
            winScreen.SetActive(true);
            time.text = "Time : " + TSScript.timer;
            score.text = "Score : " + ImportantVars.Instance.score;
        }
    }

    public void TimeSpeedrun()
    {
        ImportantVars.Instance.NewGame();
        playerobj.SetActive(true);
        hud.SetActive(true);
        mainmenu.SetActive(false);
        panel.ReanchorToRight();
        bg.SetActive(false);
        LifeCycle.Instance.Unpause();
        timespeedruntoggle = false;
        Debug.Log("im working time speedrun");
        ImportantVars.Instance.gameEndWave = int.Parse(waveEndInputField.text);
        timespeedruntoggle = true;
        startbutton.SetActive(false);
        resumebutton.SetActive(true);
        ImportantVars.Instance.EnemyCount = 0;
        importantobjm.Instantiate();
        TSScript.TimeSpeedrunUIChange();
    }

    public void TimeSpeedrunExit()
    {
        winScreen.SetActive(false);
        hud.SetActive(false);
        importantobjm.Release();
        playerobj.SetActive(false);
        startbutton.SetActive(true);
        resumebutton.SetActive(false);
        TSScript.LeaveTimeSpeedrun();

    }

    public void StartGameNow()
    {
        ImportantVars.Instance.NewGame();
        playerobj.SetActive(true);
        Debug.Log("Start Game now");
        hud.SetActive(true);
        statTree.SetActive(true);
        mainmenu.SetActive(false);
        panel.ReanchorToRight();
        bg.SetActive(false);
        LifeCycle.Instance.Unpause();
        timespeedruntoggle = false;
        startbutton.SetActive(false);
        resumebutton.SetActive(true);
        ImportantVars.Instance.EnemyCount = 0;
        if (!spawnManagerSpawned)
        {
            importantobjm.Instantiate();
            spawnManagerSpawned = true;
        }
        

    }

    public void StartGameExit()
    {
        hud.SetActive(false);
        importantobjm.Release();
        playerobj.SetActive(false);
        startbutton.SetActive(true);
        resumebutton.SetActive(false);
    }

    public void RestartSpeedrun()
    {
        //Debug.Log("about to reload scene");
        SceneManager.LoadScene("GameScene");
        //Debug.Log("scene loaded");
        TimeSpeedrun();

    }

    public void NewGameNow()
    {
        StatChangeButton[] statChangeB = multiStat.GetComponentsInChildren<StatChangeButton>();
        for (int i = 0; i < statChangeB.Length; i++)
        {
            statChangeB[i].currentClicks = 0;
            statChangeB[i].Refresh();
        }
        ImageModifier[] imgMod = multiStat.GetComponentsInChildren<ImageModifier>();
        for (int j = 0; j < imgMod.Length; j++)
        {
            imgMod[j].image.fillAmount = 0;
        }


        playerobj.GetComponentInChildren<Hitpoints>().hitpoints = playerobj.GetComponentInChildren<Hitpoints>().maxhitpoints;
        Spawner spawner1 = hudUI.ammo1;
        Spawner spawner2 = hudUI.ammo2;
        playerobj.transform.position = Vector3.zero;
        playerobj.transform.rotation = Quaternion.identity;
        playerobj.GetComponentInChildren<Hitpoints>().triggeredDeath = false;
        spawner1.bullet = defaultBullet;
        spawner2.bullet = defaultBullet;
        spawner1.ReloadNow();
        spawner2.ReloadNow();
        AdminPowers.Instance.KillAll();
        StartGameNow();



    }

    




    


    
}
