using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenu_ShopButton : BaseButton
{
    protected override void OnClick()
    {
        Observer.PostEvent(EventID.ButtonShopping_Click, new KeyValuePair<EventParameterType, object>(EventParameterType.ButtonShopping_Click_Null, null));
    }
}