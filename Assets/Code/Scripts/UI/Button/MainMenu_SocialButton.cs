using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenu_SocialButton : BaseButton
{
    protected override void OnClick()
    {
        Application.OpenURL("https://www.facebook.com/buzlc/");
    }
}