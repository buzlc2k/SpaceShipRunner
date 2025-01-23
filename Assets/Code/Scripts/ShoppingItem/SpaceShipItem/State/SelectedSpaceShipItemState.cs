using System.Collections.Generic;
using UnityEngine;

public class SelectedSpaceShipItemState : BaseSpaceShipItemState
{
    public SelectedSpaceShipItemState(SpaceShipConfig spaceShipConfig) : base(spaceShipConfig){ }
    public override void OnEnterState()
    {
        Debug.Log("Selected " + spaceShipConfig.SpaceShipID);
        Observer.PostEvent(EventID.SpaceShipItem_SelectedItem, new KeyValuePair<EventParameterType, object>(EventParameterType.SpaceShipItem_SelectedItem_SpaceShipConfig, spaceShipConfig));
    }

    public override void OnExitState()
    {
        
    }

    public override void OnStateClick()
    {
        
    }
}