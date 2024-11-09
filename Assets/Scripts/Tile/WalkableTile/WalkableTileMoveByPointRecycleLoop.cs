using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived class from ObjectMoveByPointRecycleLoop that creates a movement trajectory loop for walkable tile.
/// </summary>
public class WalkableTileMoveByPointRecycleLoop : ObjectMoveByPointRecycleLoop
{
    protected override void ResetingMoving()
    {
        base.ResetingMoving();
        //Post event that walkabletile is reseted
        Observer.PostEvent(EventID.ResetWalkableTile, new KeyValuePair<EventParameterType, object>(EventParameterType.ResetWalkableTile_WalkableTileObject, this.transform.parent.gameObject));
    }
}