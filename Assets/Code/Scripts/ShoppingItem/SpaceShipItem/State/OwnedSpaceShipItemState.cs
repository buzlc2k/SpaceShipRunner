using System.Collections.Generic;

public class OwnedSpaceShipItemState : BaseSpaceShipItemState
{
    public OwnedSpaceShipItemState(SpaceShipConfig spaceShipConfig) : base(spaceShipConfig){ }

    public override void OnEnterState()
    {
        
    }

    public override void OnExitState()
    {
        
    }

    public override void OnStateClick()
    {
        Observer.PostEvent(EventID.SpaceShipItem_OwnedItemClick, new KeyValuePair<EventParameterType, object>(EventParameterType.SpaceShipItem_OwnedItemClick_SpaceShipConfig, spaceShipConfig));
    }
}