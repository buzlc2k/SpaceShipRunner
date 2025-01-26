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
        spaceShipStateMachine.AddTransition(selectedSpaceShipItemState, ownedSpaceShipItemState, new EventPredicate(EventID.SpaceShipItem_OwnedItemClick, ((SpaceShipItemConfig)ItemConfig).ID, false));
        spaceShipStateMachine.AddTransition(selectedSpaceShipItemState, ownedSpaceShipItemState, new EventPredicate(EventID.SpaceShipItem_BuySuccess, ((SpaceShipItemConfig)ItemConfig).ID, false));
        
        spaceShipStateMachine.AddTransition(ownedSpaceShipItemState, selectedSpaceShipItemState, new EventPredicate(EventID.SpaceShipItem_OwnedItemClick, ((SpaceShipItemConfig)ItemConfig).ID));

        spaceShipStateMachine.AddTransition(buyableSpaceShipItemState, selectedSpaceShipItemState, new EventPredicate(EventID.SpaceShipItem_BuySuccess, ((SpaceShipItemConfig)ItemConfig).ID));
        //End

        //Set default state
        if(SpaceShipTrackingManager.Instance.CurrentSpaceShipID.Equals(((SpaceShipItemConfig)ItemConfig).ID))
            spaceShipStateMachine.SetState(selectedSpaceShipItemState);
        else if(SpaceShipTrackingManager.Instance.SpaceShipsOwnedID.Contains(((SpaceShipItemConfig)ItemConfig).ID))
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