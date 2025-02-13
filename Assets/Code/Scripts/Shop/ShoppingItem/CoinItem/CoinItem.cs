using System.Collections.Generic;
using UnityEngine;

public class CoinItem : BaseItem
{
    public override void InitializeItemAction()
    {
        Observer.PostEvent(EventID.WantToBuyItem, new KeyValuePair<EventParameterType, object>(EventParameterType.WantToBuyItem_Item, this));
    }
    
    public override void OnItemPuschaseSuccess()
    {
        Observer.PostEvent(EventID.LoadCoinsData, new KeyValuePair<EventParameterType, object>(EventParameterType.LoadCoinsData_NumCoinAdded, ((CoinItemConfig)ItemConfig).NumCoinInItem));
        Observer.PostEvent(EventID.CoinItem_BuySuccess, new KeyValuePair<EventParameterType, object>(EventParameterType.CoinItem_BuySuccess_CoinConfigID, ItemConfig.ID));
    }
}