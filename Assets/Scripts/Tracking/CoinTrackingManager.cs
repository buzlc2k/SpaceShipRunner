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

    protected override void OnEnable()
    {
        base.OnEnable();
    
        SetUpDelegate(); 
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        Observer.RemoveListener(EventID.Player_TakeCoin, addCoin);
    }

    protected override void LoadValue()
    {
        base.LoadValue();

        currentCoin = 0;
    }

    //Tạo các delegate để lắng nghe sự kiện
    protected virtual void SetUpDelegate(){
        addCoin ??= (param) => {
            AddCoin();
        };

        Observer.AddListener(EventID.Player_TakeCoin, addCoin);
    }

    private void AddCoin(){
        currentCoin++;
    }
}