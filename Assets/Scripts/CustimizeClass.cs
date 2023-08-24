using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustimizeClass : MonoBehaviour
{
    public Button leftArrow;
    public Button rightArrow;

    public RawImage rawImg;
    public Transform spinningThing;
    public GameObject currentModel;
    public GameObject player;
    public GameObject colorWheel;

    public Color currentColor = Color.white;

    public int choiceIndex = 0;
    [System.Serializable]
    public class PlayerShipClass
    {
        public string name;
        public GameObject modelType;
        public float healthPoints;
        public float speed;
    }
    public PlayerShipClass[] shipArray = new PlayerShipClass[]
    {
        new PlayerShipClass
        {
            name = "Speed Ship",
            healthPoints = 3f,
            speed = 1f
        },
        new PlayerShipClass
        {
            name = "Shield Ship",
            healthPoints = 4f,
            speed = 0.75f
        },
    };

    void Start()
    {
        RefreshShipModel();
        colorWheel.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
        if(choiceIndex +1 == shipArray.Length)
        {
            choiceIndex = 0;
        }
        else
        {
            choiceIndex += 1;
        }
        RefreshShipModel();
    }
    public void Prev()
    {
        if(choiceIndex -1 == -1)
        {
            choiceIndex = shipArray.Length -1;
        }
        else
        {
            choiceIndex -= 1;
        }
        RefreshShipModel();
    }
    public void RefreshShipModel()
    {
        if(currentModel != null)
        {
            Destroy(currentModel);
        }


        GameObject modelToSpawn = shipArray[choiceIndex].modelType;
        currentModel = Instantiate(modelToSpawn);
        currentModel.transform.SetParent(spinningThing);
        currentModel.transform.localPosition = Vector3.zero;
        //copy.transform.localRotation = Quaternion.identity;
        ChangeColor(currentColor);
    }

    public void ChangeColor(Color color)
    {
        currentColor = color;
        Material mat = currentModel.GetComponentInChildren<Renderer>().material;
        mat.color = currentColor;
    }

    public void ChangeHue(float hue)
    {
        ChangeColor(currentColor);
    }

    public void ConfirmShip()
    {
        ShipController sc = player.GetComponent<ShipController>();
        if (sc.shipGraphic != null)
        {
            Destroy(sc.shipGraphic);
        }
        sc.shipGraphic = Instantiate(currentModel);
        sc.shipGraphic.transform.SetParent(player.transform);
        sc.shipGraphic.transform.localPosition = Vector3.zero;
        sc.shipGraphic.transform.localRotation = Quaternion.identity;
        PlayerPrefs.SetInt("Ship Index", choiceIndex);
        Color32 c = currentColor;
        int serializedColor = CompressNumbers(c.r, c.g, c.b, c.a);
        PlayerPrefs.SetInt("Ship Color", serializedColor);

    }

    // TODO : Make function that loads the saved ship & color from player prefs

    int CompressNumbers(byte a, byte b, byte c, byte d)
    {
        return a | (b << 8) | (c << 16) | (d << 24);
    }

    void GetNumbers(int source, out byte a, out byte b, out byte c, out byte d)
    {
        a = (byte)((source >> 0) & 255);
        b = (byte)((source >> 8) & 255);
        c = (byte)((source >> 16) & 255);
        d = (byte)((source >> 24) & 255);
    }
}
