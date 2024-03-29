using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustimizeClass : MonoBehaviour
{
    const string ShipIndex = "Ship Index";
    const string ShipColor = "Ship Color";

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
        public int bulletIndex;
    }
    public PlayerShipClass[] shipArray = new PlayerShipClass[]
    {
        new PlayerShipClass
        {
            name = "Speed Ship",
            healthPoints = 3f,
            speed = 1f,
            bulletIndex = 0
        },
        new PlayerShipClass
        {
            name = "Shield Ship",
            healthPoints = 4f,
            speed = 0.75f,
            bulletIndex = 1
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
        //currentModel.gameObject.layer = 6;
        //currentModel.transform.GetChild(0).gameObject.layer = 6;
        SetObjectToLayer(currentModel, 6);
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
        Confirm(choiceIndex, currentColor);
    }
    public void Confirm(int shipIndex, Color shipColor)
    {
        ShipController sc = player.GetComponent<ShipController>();
        if (sc.shipGraphic != null)
        {
            Destroy(sc.shipGraphic);
        }
        choiceIndex = shipIndex;
        currentColor = shipColor;
        RefreshShipModel();
        player.GetComponent<ChangeBullets>().BulletIndex = shipArray[choiceIndex].bulletIndex;
        
        sc.shipGraphic = Instantiate(currentModel);
        //sc.shipGraphic.layer = 0;
        //sc.shipGraphic.transform.GetChild(0).gameObject.layer = 0;
        SetObjectToLayer(sc.shipGraphic, 0);
        sc.shipGraphic.transform.SetParent(player.transform);
        sc.shipGraphic.transform.SetSiblingIndex(0);
        sc.shipGraphic.transform.localPosition = Vector3.zero;
        sc.shipGraphic.transform.localRotation = Quaternion.identity;
        PlayerPrefs.SetInt(ShipIndex, shipIndex);
        int serializedColor = ColorToInt(shipColor);
        PlayerPrefs.SetInt(ShipColor, serializedColor);

    }

    public void SetObjectToLayer(GameObject go, int layer)
    {
        go.layer = layer;
        for (int i = 0; i< go.transform.childCount; i++)
        {
            SetObjectToLayer(go.transform.GetChild(i).gameObject, layer);
        }


    }

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

    public int ColorToInt(Color color)
    {
        Color32 c = color;
        int serializedColor = CompressNumbers(c.r, c.g, c.b, c.a);
        return serializedColor;
    }

    public Color IntToColor(int i)
    {
        int serializedColor = i;
        GetNumbers(serializedColor, out byte r, out byte g, out byte b, out byte a);
        Color32 c = new Color32(r, g, b, a);
        return c;
    }

    public void LoadShip()
    {
        int shipIndex = PlayerPrefs.GetInt(ShipIndex);
        Color shipColor = IntToColor(PlayerPrefs.GetInt(ShipColor));
        Confirm(shipIndex,shipColor);
    }
}
