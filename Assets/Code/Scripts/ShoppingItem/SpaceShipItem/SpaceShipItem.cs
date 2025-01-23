using System.Collections.Generic;
using UnityEngine;

public class SpaceShipItem : BaseItem
{ 
    public SpaceShipConfig spaceShipConfig;

    private SpaceShipStateMachine spaceShipStateMachine;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        //Load State Machine
        spaceShipStateMachine = new SpaceShipStateMachine();
    }

    protected override void Start()
    {
        base.Start();

        //load State
        var selectedSpaceShipItemState = new SelectedSpaceShipItemState(spaceShipConfig);
        var ownedSpaceShipItemState = new OwnedSpaceShipItemState(spaceShipConfig);
        var buyableSpaceShipItemState = new BuyableSpaceShipItemState(spaceShipConfig);
        //End

        //Add Trasition
        spaceShipStateMachine.AddTransition(selectedSpaceShipItemState, ownedSpaceShipItemState, new EventPredicate(EventID.SpaceShipItem_OwnedItemClick, spaceShipConfig, true));
        
        spaceShipStateMachine.AddTransition(ownedSpaceShipItemState, selectedSpaceShipItemState, new EventPredicate(EventID.SpaceShipItem_OwnedItemClick, spaceShipConfig));

        spaceShipStateMachine.AddTransition(buyableSpaceShipItemState, selectedSpaceShipItemState, new EventPredicate(EventID.SpaceShipItem_BuySuccess, spaceShipConfig));
        //End

        //Set default state
        if(SpaceShipTrackingManager.Instance.CurrentSpaceShip.Equals(spaceShipConfig))
            spaceShipStateMachine.SetState(selectedSpaceShipItemState);
        else if(SpaceShipTrackingManager.Instance.SpaceShipsOwned.Contains(spaceShipConfig))
            spaceShipStateMachine.SetState(ownedSpaceShipItemState);
        else
            spaceShipStateMachine.SetState(buyableSpaceShipItemState);
    }

    private void Update() {
        spaceShipStateMachine.StateMachineUpdate();
    }

    public void SpaceShipItemClick(){
        spaceShipStateMachine.ClickInState();
    }
}