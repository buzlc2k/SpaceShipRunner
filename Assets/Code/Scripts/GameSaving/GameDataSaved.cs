using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameDataSaved
{
    public ItemID CurrentSpaceShip;
    public List<ItemID> SpaceShipOwned = new();
    public int CurrentCoinsOwned;

    public GameDataSaved(ItemID CurrentSpaceShip, List<ItemID> SpaceShipOwned, int CurrentCoinsOwned){
        this.CurrentSpaceShip = CurrentSpaceShip;
        this.SpaceShipOwned = SpaceShipOwned;
        this.CurrentCoinsOwned = CurrentCoinsOwned;
    }
}