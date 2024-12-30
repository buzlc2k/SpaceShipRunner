using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived class from ObjMoveByPoint that creates a movement loop.
/// When the object gets close enough to the target position, it resets back to the spawn position.
/// </summary>
public abstract class ObjectMoveByStaticPointRecycleLoop : ObjMoveByStaticPointLoop
{
    protected override void InitializeResetMoving()
    {
        // Reset the object's position back to the spawn position
        this.transform.parent.position = this.spawnPoint;
    }
}
