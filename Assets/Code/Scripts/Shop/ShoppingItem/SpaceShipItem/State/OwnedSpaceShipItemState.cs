using System.Collections.Generic;

public class OwnedSpaceShipItemState : BaseSpaceShipItemState
{
    public OwnedSpaceShipItemState(SpaceShipItem SpaceShipItem) : base(SpaceShipItem){ }

    public override void OnEnterState()
    {
        SpaceShipItem.CurrentSpaceShipItemState = SpaceShipItemState.Owned;
    }

    public override void OnExitState()
    {
        
    }

    public override void InitializeStateAction()
    {
        Observer.PostEvent(EventID.SpaceShipItem_OwnedItemClick, new KeyValuePair<EventParameterType, object>(EventParameterType.SpaceShipItem_OwnedItemClick_SpaceShipConfig, SpaceShipItem.ItemConfig.ID));
    }
}