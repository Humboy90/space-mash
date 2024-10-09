using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject header;
    public TMPro.TMP_Text textbox;
    public GameObject scrollwheel;
    public GameObject keyDisplay;
    public GameObject mouseDisplay;
    public GameObject hudDisplay;
    public GameObject enemy;
    public GameObject statTree;
    public GameObject statDisplay;
    public Spawner gun1;
    public Spawner gun2;

    public GameObject[] textboxs;
    public int textboxIndex = 0;


    [System.Serializable]
    public class TutorialKey
    {
        public string name;
        public KeyCode key;
        public GameObject display;
        public TutorialKey(KeyCode k, GameObject go)
        {
            key = k;
            display = go;
            name = key.ToString();
        }
    }
    public TutorialKey[] tutkeys = new TutorialKey[]
    {
        new TutorialKey(KeyCode.W, null),
        new TutorialKey(KeyCode.A, null),
        new TutorialKey(KeyCode.S, null),
        new TutorialKey(KeyCode.D, null),
        new TutorialKey(KeyCode.Mouse1, null),
        new TutorialKey(KeyCode.Mouse0, null),

    };
         
    
    



    void Start()
    {
        gun1 = GetComponent<WeaponChange>().gunLeft;
        gun2 = GetComponent<WeaponChange>().gunRight;
        gun1.enabled = false;
        gun2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        int activebuttons = 0;
        for (int i = 0; i < tutkeys.Length; i++)
        {
            TutorialKey tutkey = tutkeys[i];
            if (tutkey.display != null && tutkey.display.activeInHierarchy && Input.GetKeyDown(tutkey.key))
            {
                tutkey.display.SetActive(false);
            }
            if (tutkey.display.activeInHierarchy)
            {
                activebuttons++;
            }
        }
        if(activebuttons == 0 && mouseDisplay.activeInHierarchy == false)
        {
            gun1.enabled = true;
            gun2.enabled = true;
            keyDisplay.SetActive(false);
            mouseDisplay.SetActive(true);
        }
        else if(activebuttons == 0 && hudDisplay.activeInHierarchy == false)
        {
            header.SetActive(false);
            mouseDisplay.SetActive(false);
            hudDisplay.SetActive(true);
            textbox.color = Color.red;
            textbox.text = "Read the descriptions as shown\nClick for next description";
            gun1.enabled = false;
            gun2.enabled = false;
            if(textboxIndex < textboxs.Length)
            {
                textboxs[textboxIndex].SetActive(true);
            }
            
        }
        if(hudDisplay.activeInHierarchy == true)
        {
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if(textboxIndex < textboxs.Length)
                {
                    textboxs[textboxIndex].SetActive(false);
                    textboxIndex++;
                    gun1.enabled = false;
                    gun2.enabled = false;
                    if (textboxIndex < textboxs.Length)
                    { 
                        textboxs[textboxIndex].SetActive(true);
                    }
                    else
                    {
                        gun1.enabled = true;
                        gun2.enabled = true;
                        enemy.GetComponent<Hitpoints>().maxhitpoints = 3;
                        enemy.GetComponent<Hitpoints>().hitpoints = 3;
                        statTree.SetActive(true);
                        statDisplay.SetActive(true);
                    }
                }
                
                

            }
        }

        if (mouseDisplay.activeInHierarchy && Input.mouseScrollDelta.y != 0)
        {
            scrollwheel.SetActive(false);
        }
    }


}
