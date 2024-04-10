using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageModifier : MonoBehaviour
{
    public Image image;


    public void AddFillAmount(float addAMT)
    {
        image.fillAmount += addAMT;
    }
}
