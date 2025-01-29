using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Image expBar;
    public TMPro.TMP_Text text;

    public int level;
    public float[] maxExpNeedForLVLup = {1,2,3,4,5,6,7,8,9,10};
    public float expSum;
    public float currentProgress = 0;
    public int pointsToUse;

    public static ExpBar Instance;

    // TODO : make singlton exp bar and add enemy exp to bar on death

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddExpPoints(float num)
    {
        expSum += num;
        


        for (int i = 0; level < maxExpNeedForLVLup.Length && expSum >= maxExpNeedForLVLup[level]; i++)
        {
            expSum -= maxExpNeedForLVLup[level];
            level += 1;
            pointsToUse += 1;
            text.text = "Level " + level + " : " + currentProgress + "%";
        }


        if(level >= maxExpNeedForLVLup.Length)
        {
            currentProgress = expSum / maxExpNeedForLVLup[maxExpNeedForLVLup.Length - 1];
            text.text = "Level " + level + " : " + currentProgress + "%";
        }
        else
        {
            currentProgress = expSum / maxExpNeedForLVLup[level];
            text.text = "Level " + level + " : " + currentProgress + "%";
        }

        
        expBar.fillAmount = currentProgress;
    }
}
