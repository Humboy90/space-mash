using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEditor : MonoBehaviour
{
    public Text text;
    public bool onoff;

    public void OnClickTextChange()
    {
        
        if (onoff == true)
        {
            Debug.Log("clicky click 1");
            onoff = false;
            text.text = "Difficulty : Easy";
        }
        else if (onoff == false)
        {
            Debug.Log("clicky click 2");
            onoff = true;
            text.text = "Difficulty : Hard";
        }
        
    }
}
