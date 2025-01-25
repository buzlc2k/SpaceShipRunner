using System.Collections.Generic;

public class BuyableSpaceShipItemState : BaseSpaceShipItemState
{
    public BuyableSpaceShipItemState(SpaceShipItem SpaceShipItem) : base(SpaceShipItem){ }

    public override void OnEnterState()
    {
        SpaceShipItem.CurrentSpaceShipItemState = SpaceShipItemState.Buyable;
    }

    public override void OnExitState()
    {
        
    }

    public override void InitializeStateAction()
    {
        Observer.PostEvent(EventID.WantToBuyItem, new KeyValuePair<EventParameterType, object>(EventParameterType.WantToBuyItem_ItemConfig, SpaceShipItem.ItemConfig));
    }
}