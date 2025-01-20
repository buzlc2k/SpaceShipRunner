using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipTrackingManager : Singleton<SpaceShipTrackingManager>
{
    private SpaceShipConfig currentSpaceShip; 
    private List<SpaceShipConfig> spaceShipsOwned = new();

    private Action<KeyValuePair<EventParameterType, object>> setCurrentSpaceShip;
    private Action<KeyValuePair<EventParameterType, object>> addSpaceShipOwner;

    #region Property

    public SpaceShipConfig CurrentSpaceShip { get => currentSpaceShip; }
    public List<SpaceShipConfig> SpaceShipsOwned { get => spaceShipsOwned; }

    #endregion

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        setCurrentSpaceShip = (param) => {
            SetCurrentSpaceShip((SpaceShipConfig)param.Value);
        };

        addSpaceShipOwner = (param) => {
            if(param.Value is SpaceShipConfig spaceShipConfig) AddSpaceShipOwner(spaceShipConfig);
            else AddSpaceShipOwner((List<SpaceShipConfig>)param.Value);

        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.LoadCurrentSpaceShip, setCurrentSpaceShip);
        Observer.AddListener(EventID.LoadSpaceShipOwned, addSpaceShipOwner);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.LoadCurrentSpaceShip, setCurrentSpaceShip);
        Observer.RemoveListener(EventID.LoadSpaceShipOwned, addSpaceShipOwner);
    }

    private void SetCurrentSpaceShip(SpaceShipConfig currentSpaceShip){
        this.currentSpaceShip = currentSpaceShip;
    }

    private void AddSpaceShipOwner(SpaceShipConfig spaceShipAdded){
        spaceShipsOwned.Add(spaceShipAdded);
    }

    private void AddSpaceShipOwner(List<SpaceShipConfig> spaceShipAdded){
        spaceShipsOwned.AddRange(spaceShipAdded);
    }
}