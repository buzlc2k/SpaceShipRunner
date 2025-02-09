using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : ButMonobehavior
{
    public ItemConfig ItemConfig;

    public abstract void InitializeItemAction();
    
    public abstract void OnItemPuschaseSuccess();

    public abstract void OnItemPuschaseFailed();
}