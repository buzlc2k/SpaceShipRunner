using System.Collections.Generic;

public class CoinItem : BaseItem
{
    public override void InitializeItemAction()
    {
        Observer.PostEvent(EventID.WantToBuyItem, new KeyValuePair<EventParameterType, object>(EventParameterType.WantToBuyItem_ItemConfig, ItemConfig));
    }
}