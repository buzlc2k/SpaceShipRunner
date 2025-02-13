using UnityEngine;

public class ScreenManager : ButMonobehavior
{
    [SerializeField] ScreenManagerConfig screenManagerConfig;

    protected override void Start()
    {
        base.Start();

        SetRatio(screenManagerConfig.WidthScale, screenManagerConfig.HeightScale);
    }

    private void SetRatio(float wScale, float hScale)
    {
        if ((((float)Screen.width) / ((float)Screen.height)) > wScale / hScale)
        {
            Screen.SetResolution((int)(((float)Screen.height) * (wScale / hScale)), Screen.height, true);
        }
        else
        {
            Screen.SetResolution(Screen.width, (int)(((float)Screen.width) * (hScale / wScale)), true);
        }
    }
}