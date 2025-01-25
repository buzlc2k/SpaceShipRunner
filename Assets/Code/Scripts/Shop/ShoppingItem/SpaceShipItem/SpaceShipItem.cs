using System.Collections.Generic;
using UnityEngine;

public enum SpaceShipItemState{
    None = 0,
    Selected,
    Owned,
    Buyable
}

public class SpaceShipItem : BaseItem
{
    public SpaceShipItemState CurrentSpaceShipItemState;

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
        var selectedSpaceShipItemState = new SelectedSpaceShipItemState(this);
        var ownedSpaceShipItemState = new OwnedSpaceShipItemState(this);
        var buyableSpaceShipItemState = new BuyableSpaceShipItemState(this);
        //End

        //Add Trasition
        spaceShipStateMachine.AddTransition(selectedSpaceShipItemState, ownedSpaceShipItemState, new EventPredicate(EventID.SpaceShipItem_OwnedItemClick, (SpaceShipConfig)ItemConfig, false));
        spaceShipStateMachine.AddTransition(selectedSpaceShipItemState, ownedSpaceShipItemState, new EventPredicate(EventID.SpaceShipItem_BuySuccess, (SpaceShipConfig)ItemConfig, false));
        
        spaceShipStateMachine.AddTransition(ownedSpaceShipItemState, selectedSpaceShipItemState, new EventPredicate(EventID.SpaceShipItem_OwnedItemClick, (SpaceShipConfig)ItemConfig));

        spaceShipStateMachine.AddTransition(buyableSpaceShipItemState, selectedSpaceShipItemState, new EventPredicate(EventID.SpaceShipItem_BuySuccess, (SpaceShipConfig)ItemConfig));
        //End

        //Set default state
        if(SpaceShipTrackingManager.Instance.CurrentSpaceShip.Equals((SpaceShipConfig)ItemConfig))
            spaceShipStateMachine.SetState(selectedSpaceShipItemState);
        else if(SpaceShipTrackingManager.Instance.SpaceShipsOwned.Contains((SpaceShipConfig)ItemConfig))
            spaceShipStateMachine.SetState(ownedSpaceShipItemState);
        else
            spaceShipStateMachine.SetState(buyableSpaceShipItemState);
    }

    private void Update() {
        spaceShipStateMachine.StateMachineUpdate();
    }

    public override void InitializeItemAction(){
        spaceShipStateMachine.InitializeStateAction();
    }
}