using System;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipSaver : BaseSaver
{
    public override void LoadData(){
        Observer.PostEvent(EventID.LoadCurrentSpaceShip, new KeyValuePair<EventParameterType, object>(EventParameterType.LoadCurrentSpaceShip_CurrentSpaceShip, SaveGameManager.Instance.GameDataSaved.CurrentSpaceShip));
        Observer.PostEvent(EventID.LoadSpaceShipOwned, new KeyValuePair<EventParameterType, object>(EventParameterType.LoadSpaceShipOwned_SpaceShipOwned, SaveGameManager.Instance.GameDataSaved.SpaceShipOwned));
    }
    public override void SaveData(){
        SaveGameManager.Instance.GameDataSaved.CurrentSpaceShip = SpaceShipTrackingManager.Instance.CurrentSpaceShip;
        SaveGameManager.Instance.GameDataSaved.SpaceShipOwned = SpaceShipTrackingManager.Instance.SpaceShipsOwned;
    }
}