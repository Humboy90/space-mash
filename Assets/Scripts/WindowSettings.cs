using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSettings : MonoBehaviour
{
    private const int DEFAULT = -1;
    public Vector2Int[] resolutions = {
        new Vector2Int(DEFAULT,DEFAULT),
        new Vector2Int(640,480),
        new Vector2Int(1024,768)
    };

    public int resIndex = 0;
    public int screenMode = (int)FullScreenMode.FullScreenWindow;
    public int ResolutionIndex
    {
        get => resIndex;

        set => resIndex = value;
    }
    public int ScreenMode
    {
        get => screenMode;

        set => screenMode = value;
    }
    void Start()
    {
        resolutions[0] = new Vector2Int(Screen.currentResolution.width, Screen.currentResolution.height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetResolution(int resIndex)
    {
        Vector2Int r = resolutions[resIndex];
        Screen.SetResolution(r.x, r.y, false);
    }

    public void RefreshResolution()
    {
        Vector2Int r = resolutions[resIndex];
        Screen.SetResolution(r.x, r.y, (FullScreenMode) screenMode);
    }

}
