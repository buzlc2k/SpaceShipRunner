using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived class from ObjMoveByPoint that creates a movement loop.
/// When the object gets close enough to the target position, it resets back to the spawn position.
/// </summary>
public class ObjectMoveByPointRecycleLoop : ObjMoveByPointLoop
{
    /// <summary>
    /// Overrides the ResetMovingAfterReachTarget method to reset the object's position.
    /// If the object comes within the specified distance (distanceToReset) from the target position,
    /// it resets to the initial spawn position, creating a continuous movement loop.
    /// </summary>
    protected override void ResetMovingAfterReachTarget()
    {
        // Check if the object is within the specified reset distance from the target position
        if (Vector3.Distance(this.transform.parent.position, targetPosition) < distanceToReset)
        {
            // Reset the object's position back to the spawn position
            this.transform.parent.position = spawnPosition;
        }
    }
}
