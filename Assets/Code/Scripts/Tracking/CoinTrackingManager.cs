using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrackingManager : Singleton<CoinTrackingManager>
{
    private float currentCoin;

    private Action<KeyValuePair<EventParameterType, object>> addCoin;

    #region Property

    public float CurrentCoin { get => currentCoin; }

    #endregion

    protected override void LoadValue()
    {
        base.LoadValue();

        currentCoin = 0;
    }

    //Tạo các delegate để lắng nghe sự kiện
    protected override void SetUpDelegate(){
        addCoin ??= (param) => {
            AddCoin();
        };
    }

    protected override void AddListenerToObsever()
    {
        base.AddListenerToObsever();

        Observer.AddListener(EventID.Player_TakeCoin, addCoin);
    }

    protected override void RemoveListenerFromObsever()
    {
        base.RemoveListenerFromObsever();

        Observer.RemoveListener(EventID.Player_TakeCoin, addCoin);
    }

    private void AddCoin(){
        currentCoin++;
    }
}