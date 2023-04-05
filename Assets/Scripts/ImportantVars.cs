using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ImportantVars : MonoBehaviour
{
    public int score;
    public TMP_Text text;
    public static ImportantVars Instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score : " + score.ToString();
    }

    private void Awake()
    {
        Instance = this;
    }
}
