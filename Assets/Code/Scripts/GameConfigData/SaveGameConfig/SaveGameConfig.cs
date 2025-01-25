using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/SaveGameConfig/SaveGameConfig")]
public class SaveGameConfig : ScriptableObject
{
    public string GameDataSaved_ID = "SavingData1";
    public SpaceShipConfig CurrentSpaceShip;
    public List<SpaceShipConfig> SpaceShipOwned;
    public ItemID urrentSpaceShip;
    public List<ItemID> paceShipOwned;
    public int CurrentCoinsOwned;
}