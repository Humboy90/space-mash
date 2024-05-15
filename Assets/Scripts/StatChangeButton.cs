using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatChangeButton : MonoBehaviour
{

    public int maxClick => valuePerClick.Length;
    public int currentClicks;
    public float[] valuePerClick = { 1, 2, 3, 4 };

    public ImageModifier im;

    [System.Serializable] public class UnityEvent_Float : UnityEvent<float>
    {

    }
    public UnityEvent_Float varToChange;

    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        if (ExpBar.Instance.pointsToUse >= 1)
        {
            if (currentClicks < maxClick - 1)
            {
                currentClicks += 1;
                Refresh();
            }
            ExpBar.Instance.pointsToUse -= 1;
            im.AddFillAmount(.2f);
        }
        
        
    }


    public void Refresh()
    {
        varToChange.Invoke(valuePerClick[currentClicks]);
    }

    //public void ChangeStat(ImportantVars iv)
    //{
    //    if(maxClick != 0)
    //    {
            
    //    }
    //}
}
