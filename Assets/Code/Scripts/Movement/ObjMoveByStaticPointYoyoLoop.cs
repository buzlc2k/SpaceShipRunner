using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived class from ObjMoveByPoint that creates a movement loop.
/// When the object gets close enough to the target position, it move back to the spawn position.
/// </summary>
public abstract class ObjMoveByStaticPointYoyoLoop : ObjMoveByStaticPointLoop
{
    protected override void InitializeResetMoving(){
        // Swap value between target point and spawn point
        (targetPoint, spawnPoint) = (spawnPoint, targetPoint);
    }
}