using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiStats : MonoBehaviour
{

    public GameObject prefab;


    [System.Serializable]
    public class StatData
    {
        public string name;
        public Color color;
        public StatChangeButton.UnityEvent_Float varToEdit;
        public float[] statIncrease;
    }
    [ContextMenuItem(nameof(CreateButtons), nameof(CreateButtons))]
    public StatData[] stats = new StatData[]
    {
        new StatData{name = "Speed", color = Color.blue},
        new StatData{name = "Firerate", color = Color.Lerp(Color.blue,Color.cyan,.5f)},
        new StatData{name = "Weapon Damage", color = Color.cyan},
        new StatData{name = "Weapon Range", color = Color.Lerp(Color.cyan,Color.green,.5f)},
        new StatData{name = "Weapon Speed", color = Color.green},
        new StatData{name = "Max Health", color = Color.yellow},
        new StatData{name = "Health Regen", color = Color.Lerp(Color.red,Color.yellow,.5f)},
        new StatData{name = "Max Ammo", color = Color.red},

    };


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
        for (int i =0; i < stats.Length; i++)
        {
            GameObject InstantiatedOBJ = Instantiate(prefab);

            InstantiatedOBJ.name = stats[i].name;

            ColorBlock newButtonColors = InstantiatedOBJ.transform.Find("Button").GetComponentInChildren<Button>().colors;
            newButtonColors.normalColor = stats[i].color;
            newButtonColors.highlightedColor = Color.Lerp(stats[i].color, Color.white,.5f);
            newButtonColors.pressedColor = Color.Lerp(stats[i].color, Color.black, .5f);
            newButtonColors.selectedColor = stats[i].color;
            InstantiatedOBJ.transform.Find("Button").GetComponentInChildren<Button>().colors = newButtonColors;
            InstantiatedOBJ.transform.Find("Button").GetComponentInChildren<Image>().color = stats[i].color;
            InstantiatedOBJ.transform.Find("Bar").GetComponentInChildren<Image>().color = stats[i].color;

            InstantiatedOBJ.transform.GetComponentInChildren<TMPro.TMP_Text>().text = stats[i].name;

            InstantiatedOBJ.transform.GetComponentInChildren<StatChangeButton>().valuePerClick = stats[i].statIncrease;
            InstantiatedOBJ.transform.GetComponentInChildren<StatChangeButton>().varToChange = stats[i].varToEdit;


            InstantiatedOBJ.transform.SetParent(transform, false);
        }
    }
}
