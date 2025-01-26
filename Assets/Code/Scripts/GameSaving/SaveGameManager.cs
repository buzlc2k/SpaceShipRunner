using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameManager : Singleton<SaveGameManager>
{
    public GameDataSaved GameDataSaved;
    [SerializeField] SaveGameConfig saveGameConfig;

    [SerializeField] private List<BaseSaver> savers = new();

    private Action<KeyValuePair<EventParameterType, object>> saveData;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        GameDataSaved = null;

        if(savers == null || savers.Count == 0){
            GetComponentsInChildren<BaseSaver>(savers);
        }
    }

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        saveData = (param) => {
            if(param.Key.Equals(EventParameterType.ADS_WatchFullAds_Placement))
                if(!param.Value.Equals(PlacementID.GetCoinButton)) return;
            SaveData();
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.ButtonReloadGame_Click, saveData);
        Observer.AddListener(EventID.SpaceShipItem_BuySuccess, saveData);
        Observer.AddListener(EventID.CoinItem_BuySuccess, saveData);
        Observer.AddListener(EventID.ADS_WatchFullAds, saveData);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.ButtonReloadGame_Click, saveData);
        Observer.RemoveListener(EventID.SpaceShipItem_BuySuccess, saveData);
        Observer.RemoveListener(EventID.CoinItem_BuySuccess, saveData);
        Observer.RemoveListener(EventID.ADS_WatchFullAds, saveData);
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        LoadData();
    }

    private void OnApplicationPause(bool pauseStatus) {
        if(pauseStatus) SaveData();
    }

    private void OnApplicationQuit() {
        SaveData();
    }

    private void LoadData(){
        string jsonString = SaveSystem.HasKey(saveGameConfig.GameDataSaved_ID) 
                ? SaveSystem.GetString(saveGameConfig.GameDataSaved_ID) 
                : null;

        GameDataSaved = !string.IsNullOrEmpty(jsonString) 
                ? JsonUtility.FromJson<GameDataSaved>(jsonString) 
                : new GameDataSaved(saveGameConfig.CurrentSpaceShip, saveGameConfig.SpaceShipOwned, saveGameConfig.CurrentCoinsOwned);

        //Set Game Data Saved to Game Running Data
        foreach(var saver in savers){
            saver.LoadData();
        }
    }

    private void SaveData(){
        //Set Game Running Data to Game Data Saved
        foreach(var saver in savers){
            saver.SaveData();
        }

        string jsonString = JsonUtility.ToJson(GameDataSaved);

        SaveSystem.SetString(saveGameConfig.GameDataSaved_ID, jsonString);
        SaveSystem.SaveToDisk();
    }
}