using System;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipSaver : BaseSaver
{
    public override void LoadData(){
        Observer.PostEvent(EventID.LoadCurrentSpaceShipData, new KeyValuePair<EventParameterType, object>(EventParameterType.LoadCurrentSpaceShipData_CurrentSpaceShip, SaveGameManager.Instance.GameDataSaved.CurrentSpaceShip));
        Observer.PostEvent(EventID.LoadSpaceShipOwnedData, new KeyValuePair<EventParameterType, object>(EventParameterType.LoadSpaceShipOwnedData_SpaceShipOwned, SaveGameManager.Instance.GameDataSaved.SpaceShipOwned));
    }
    public override void SaveData(){
        SaveGameManager.Instance.GameDataSaved.CurrentSpaceShip = SpaceShipTrackingManager.Instance.CurrentSpaceShip;
        SaveGameManager.Instance.GameDataSaved.SpaceShipOwned = SpaceShipTrackingManager.Instance.SpaceShipsOwned;
    }
}