using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameDataSaved
{
    public SpaceShipConfig CurrentSpaceShip;
    public List<SpaceShipConfig> SpaceShipOwned = new();
    public int CurrentCoinsOwned;

    public GameDataSaved(SpaceShipConfig CurrentSpaceShip, List<SpaceShipConfig> SpaceShipOwned, int CurrentCoinsOwned){
        this.CurrentSpaceShip = CurrentSpaceShip;
        this.SpaceShipOwned = SpaceShipOwned;
        this.CurrentCoinsOwned = CurrentCoinsOwned;
    }
}