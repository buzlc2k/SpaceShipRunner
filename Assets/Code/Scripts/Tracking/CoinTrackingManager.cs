using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrackingManager : Singleton<CoinTrackingManager>
{
    private int currentCoinGained; 
    private int currentPointCoin;
    private int currentTotalCoin;
    private int totalCoin;

    private Action<KeyValuePair<EventParameterType, object>> addCoinGained;
    private Action<KeyValuePair<EventParameterType, object>> setPointCoin;
    private Action<KeyValuePair<EventParameterType, object>> setCurrentTotalCoin;
    private Action<KeyValuePair<EventParameterType, object>> setTotalCoin;

    #region Property

    public int CurrentCoinGained { get => currentCoinGained; }
    public int CurrentPointCoin { get => currentPointCoin; }
    public int CurrentTotalCoin { get => currentTotalCoin; }
    public int TotalCoins { get => totalCoin; }

    #endregion

    protected override void LoadValue()
    {
        base.LoadValue();

        currentCoinGained = 0;
        currentPointCoin = 0;
        currentTotalCoin = 0;
        totalCoin = 0;
    }

    //Tạo các delegate để lắng nghe sự kiện
    protected override void SetUpDelegate(){
        base.SetUpDelegate();

        addCoinGained ??= (param) => {
            AddCoinGained();
        };

        setPointCoin ??= (param) => {
            SetPointCoint();
        };

        setCurrentTotalCoin ??= (param) => {
            SetCurentTotalCoin();
        };

        setTotalCoin ??= (param) => {
            SetTotalCoin((int)param.Value);
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.Player_TakeCoin, addCoinGained);

        Observer.AddListener(EventID.EnterGameResultState, setPointCoin);

        Observer.AddListener(EventID.EnterGameResultState, setCurrentTotalCoin);

        Observer.AddListener(EventID.LoadCoinsData, setTotalCoin);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.Player_TakeCoin, addCoinGained);

        Observer.RemoveListener(EventID.EnterGameResultState, setPointCoin);

        Observer.RemoveListener(EventID.EnterGameResultState, setCurrentTotalCoin);

        Observer.RemoveListener(EventID.LoadCoinsData, setTotalCoin);
    }

    private void AddCoinGained(){
        currentCoinGained++;
    }

    private void SetPointCoint(){
        currentPointCoin = (int)(PointTrackingManager.Instance.CurrentPoint / 10);
    }

    private void SetCurentTotalCoin(int multiply = 1){
        currentTotalCoin = (currentCoinGained + currentPointCoin) * multiply;
    }

    private void SetTotalCoin(int coinAdded){
        totalCoin += coinAdded;
    }
}