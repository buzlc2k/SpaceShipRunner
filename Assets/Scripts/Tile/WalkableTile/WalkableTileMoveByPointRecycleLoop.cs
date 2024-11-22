using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived class from ObjectMoveByPointRecycleLoop that creates a recycle movement trajectory loop for walkable tile.
/// </summary>
public class WalkableTileMoveByPointRecycleLoop : ObjectMoveByStaticPointRecycleLoop
{
    [Header("WalkableTileMoveByPointRecycleLoop")]
    protected WalkableTileCtrl walkableTileCtrl;
    
    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<WalkableTileCtrl>();
    }
    protected override void PerformReseting()
    {
        base.PerformReseting();
        //Post event that walkabletile is reseted
        Observer.PostEvent(EventID.ResetWalkableTile, new KeyValuePair<EventParameterType, object>(EventParameterType.ResetWalkableTile_WalkableTileObject, this.transform.parent.gameObject));
    }
}