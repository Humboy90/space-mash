using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OnKeyPress : MonoBehaviour
{
    public KeyCode key = KeyCode.Escape;
    public UnityEvent onKeyPress; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            doActivateTrigger();
        }
    }
    public void doActivateTrigger()
    {
        onKeyPress.Invoke();
    }
    public void Toggle(GameObject gobj)
    {
        if (gobj.activeSelf)
        {
            gobj.SetActive(false);
        }
        else
        {
            gobj.SetActive(true);
        }
    }

    public void ClickButton(Button button)
    {
        button.onClick.Invoke();
    }
}
