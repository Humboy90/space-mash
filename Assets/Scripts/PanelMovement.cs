using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMovement : MonoBehaviour
{
    public RectTransform panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReanchorToRight()
    {
        panel.anchorMax = panel.anchorMin = new Vector2(1, 0.5f);
        panel.pivot = new Vector2(1, 0.5f);
    }
}
