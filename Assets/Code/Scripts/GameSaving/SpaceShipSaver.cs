using System;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipSaver : BaseSaver
{
    public override void LoadData(){
        Observer.PostEvent(EventID.LoadCurrentSpaceShipData, new KeyValuePair<EventParameterType, object>(EventParameterType.LoadCurrentSpaceShipData_CurrentSpaceShipID, SaveGameManager.Instance.GameDataSaved.CurrentSpaceShip));
        Observer.PostEvent(EventID.LoadSpaceShipOwnedData, new KeyValuePair<EventParameterType, object>(EventParameterType.LoadSpaceShipOwnedData_SpaceShipOwnedIDs, SaveGameManager.Instance.GameDataSaved.SpaceShipOwned));
    }
    public override void SaveData(){
        SaveGameManager.Instance.GameDataSaved.CurrentSpaceShip = SpaceShipTrackingManager.Instance.CurrentSpaceShipID;
        SaveGameManager.Instance.GameDataSaved.SpaceShipOwned = SpaceShipTrackingManager.Instance.SpaceShipsOwnedID;
    }
}