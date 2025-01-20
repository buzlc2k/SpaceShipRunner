using System.Collections.Generic;
using UnityEngine;

public class SaveGameManager : Singleton<SaveGameManager>
{
    private string jsonString;
    public GameDataSaved GameDataSaved;
    [SerializeField] SaveGameConfig saveGameConfig;

    [SerializeField] private List<BaseSaver> savers = new();

    protected override void LoadComponents()
    {
        base.LoadComponents();

        GameDataSaved = null;

        if(savers == null || savers.Count == 0){
            GetComponentsInChildren<BaseSaver>(savers);
        }
    }

    protected override void LoadValue()
    {
        base.LoadValue();

        jsonString = "";
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
        jsonString = SaveSystem.HasKey(saveGameConfig.GameDataSaved_ID) 
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

        jsonString = JsonUtility.ToJson(GameDataSaved);

        SaveSystem.SetString(saveGameConfig.GameDataSaved_ID, jsonString);
        SaveSystem.SaveToDisk();
    }
}