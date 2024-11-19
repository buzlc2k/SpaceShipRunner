using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived class from ObjMoveByPoint that creates a movement loop.
/// When the object gets close enough to the target position, it move back to the spawn position.
/// </summary>
public class ObjMoveByStaticPointYoyoLoop : ObjMoveByStaticPointLoop
{
    protected override void ResetingMoving(){
        // Reset the object's position back to the spawn position
        (targetPoint, spawnPoint) = (spawnPoint, targetPoint);
    }
}