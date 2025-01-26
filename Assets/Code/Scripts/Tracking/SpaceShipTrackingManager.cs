using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipTrackingManager : Singleton<SpaceShipTrackingManager>
{
    private ItemID currentSpaceShipID; 
    private List<ItemID> spaceShipsOwnedID = new();

    private Action<KeyValuePair<EventParameterType, object>> setCurrentSpaceShip;
    private Action<KeyValuePair<EventParameterType, object>> addSpaceShipOwner;

    #region Property

    public ItemID CurrentSpaceShipID { get => currentSpaceShipID; }
    public List<ItemID> SpaceShipsOwnedID { get => spaceShipsOwnedID; }

    #endregion

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        setCurrentSpaceShip = (param) => {
            SetCurrentSpaceShip((ItemID)param.Value);
        };

        addSpaceShipOwner = (param) => {
            if(param.Value is ItemID spaceShipConfig) AddSpaceShipOwner(spaceShipConfig);
            else AddSpaceShipOwner((List<ItemID>)param.Value);

        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.LoadCurrentSpaceShipData, setCurrentSpaceShip);
        Observer.AddListener(EventID.LoadSpaceShipOwnedData, addSpaceShipOwner);
        Observer.AddListener(EventID.SpaceShipItem_SelectedItem, setCurrentSpaceShip);
        Observer.AddListener(EventID.SpaceShipItem_BuySuccess, setCurrentSpaceShip);
        Observer.AddListener(EventID.SpaceShipItem_BuySuccess, addSpaceShipOwner);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.LoadCurrentSpaceShipData, setCurrentSpaceShip);
        Observer.RemoveListener(EventID.LoadSpaceShipOwnedData, addSpaceShipOwner);
        Observer.RemoveListener(EventID.SpaceShipItem_SelectedItem, setCurrentSpaceShip);
        Observer.RemoveListener(EventID.SpaceShipItem_BuySuccess, setCurrentSpaceShip);
        Observer.RemoveListener(EventID.SpaceShipItem_BuySuccess, addSpaceShipOwner);
    }

    private void SetCurrentSpaceShip(ItemID currentSpaceShipID){
        this.currentSpaceShipID = currentSpaceShipID;
        Observer.PostEvent(EventID.SetCurrentSpaceShipSuccess, new KeyValuePair<EventParameterType, object>(EventParameterType.SetCurrentSpaceShipSuccess_Null, null));
    }

    private void AddSpaceShipOwner(ItemID spaceShipAddedID){
        spaceShipsOwnedID.Add(spaceShipAddedID);
    }

    private void AddSpaceShipOwner(List<ItemID> spaceShipAddedID){
        spaceShipsOwnedID.AddRange(spaceShipAddedID);
    }
}