using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrackingManager : Singleton<CoinTrackingManager>
{
    private int currentCoinGained; 
    private int currentPointCoin;
    private int totalCoin;

    private Action<KeyValuePair<EventParameterType, object>> addCoinGained;
    private Action<KeyValuePair<EventParameterType, object>> setPointCoinAndTotalCoin;

    #region Property

    public int CurrentCoinGained { get => currentCoinGained; }
    public int CurrentPointCoin { get => currentPointCoin; }
    public int TotalCoin { get => totalCoin; }

    #endregion

    protected override void LoadValue()
    {
        base.LoadValue();

        currentCoinGained = 0;
        currentPointCoin = 0;
    }

    //Tạo các delegate để lắng nghe sự kiện
    protected override void SetUpDelegate(){
        base.SetUpDelegate();

        addCoinGained ??= (param) => {
            AddCoinGained();
        };

        setPointCoinAndTotalCoin ??= (param) => {
            SetPointCoint();
            SetTotalCoin();
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.Player_TakeCoin, addCoinGained);
        Observer.AddListener(EventID.EnterGameResultState, setPointCoinAndTotalCoin);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.Player_TakeCoin, addCoinGained);
        Observer.RemoveListener(EventID.EnterGameResultState, setPointCoinAndTotalCoin);
    }

    private void AddCoinGained(){
        currentCoinGained++;
    }

    private void SetPointCoint(){
        currentPointCoin = (int)(PointTrackingManager.Instance.CurrentPoint / 10);
    }

    private void SetTotalCoin(int multiply = 1){
        totalCoin = (currentCoinGained + currentPointCoin) * multiply;
    }
}