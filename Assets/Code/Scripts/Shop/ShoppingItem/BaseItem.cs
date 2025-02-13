using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : ButMonobehavior
{
    public ItemConfig ItemConfig;

    public abstract void InitializeItemAction();
    
    public abstract void OnItemPuschaseSuccess();

    public virtual void OnItemPuschaseFailed(){
        Observer.PostEvent(EventID.Item_BuyFailed, new KeyValuePair<EventParameterType, object>(EventParameterType.Item_BuyFailed_Null, null));
    }
}