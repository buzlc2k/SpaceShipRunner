using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived class from ObjectMoveByPointRecycleLoop that creates a recycle movement trajectory loop for walkable tile.
/// </summary>
public class WalkableTileMoveByPointRecycleLoop : ObjectMoveByStaticPointRecycleLoop
{
    protected override object GetObjCtrl()
    {
        return transform.parent.GetComponent<WalkableTileCtrl>();
    }

    protected override void SetObjMovementConfig()
    {
        objMovementConfig = ((WalkableTileCtrl)GetObjCtrl()).walkableTileConfig.WalkableTileMovementConfig;
        base.SetObjMovementConfig();
    }

    protected override bool CheckCanUpdateMoving()
    {
        return base.CheckCanUpdateMoving() 
            || GameManager.Instance.CurrentGameState.Equals(GameState.StartTransition)
            || GameManager.Instance.CurrentGameState.Equals(GameState.MainMenu)
            || GameManager.Instance.CurrentGameState.Equals(GameState.Shopping);
    }

    protected override void InitializeResetMoving()
    {
        base.InitializeResetMoving();
        //Post event that walkabletile is reseted
        Observer.PostEvent(EventID.ResetWalkableTile, new KeyValuePair<EventParameterType, object>(EventParameterType.ResetWalkableTile_WalkableTileObject, transform.parent.gameObject));
    }
}