using System;
using System.Collections.Generic;
using UnityEngine;

public class ConfenttiVFX_CongratulationPartical : BaseUIVFX
{
    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.CoinItem_BuySuccess, playUIVFXPartical);
        Observer.AddListener(EventID.SpaceShipItem_BuySuccess, playUIVFXPartical);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.CoinItem_BuySuccess, playUIVFXPartical);
        Observer.RemoveListener(EventID.SpaceShipItem_BuySuccess, playUIVFXPartical);
    }
}