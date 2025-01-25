using System.Collections.Generic;
using UnityEngine;

public class SelectedSpaceShipItemState : BaseSpaceShipItemState
{
    public SelectedSpaceShipItemState(SpaceShipItem SpaceShipItem) : base(SpaceShipItem){ }
    public override void OnEnterState()
    {
        Observer.PostEvent(EventID.SpaceShipItem_SelectedItem, new KeyValuePair<EventParameterType, object>(EventParameterType.SpaceShipItem_SelectedItem_SpaceShipConfig, SpaceShipItem.ItemConfig));
        SpaceShipItem.CurrentSpaceShipItemState = SpaceShipItemState.Selected;
    }

    public override void OnExitState()
    {
        
    }

    public override void InitializeStateAction()
    {
        
    }
}