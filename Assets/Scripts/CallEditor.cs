using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEditor : MonoBehaviour
{

    public static CallEditor Instance;

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

    public GameObject importantUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateButtons()
    {
        importantUI.GetComponent<StartGame>().multiStat.CreateButtons();
    }

}
