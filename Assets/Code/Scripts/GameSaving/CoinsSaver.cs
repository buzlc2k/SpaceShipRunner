using System.Collections.Generic;
using UnityEngine;

public class CoinsSaver : BaseSaver
{
    public override void LoadData(){
        Observer.PostEvent(EventID.LoadCoinsData, new KeyValuePair<EventParameterType, object>(EventParameterType.LoadCoinsData_TotalCoins, SaveGameManager.Instance.GameDataSaved.CurrentCoinsOwned));
    }
    public override void SaveData(){
        SaveGameManager.Instance.GameDataSaved.CurrentCoinsOwned = CoinTrackingManager.Instance.TotalCoins;
    }
}