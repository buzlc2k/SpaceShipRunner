using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/SaveGameConfig/SaveGameConfig")]
public class SaveGameConfig : ScriptableObject
{
    public string GameDataSaved_ID = "SavingData1";
    public ItemID CurrentSpaceShip;
    public List<ItemID> SpaceShipOwned;
    public int CurrentCoinsOwned;
}