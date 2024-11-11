using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived class extending ObjMovement allows objects to reset their movement based on a custom logic.
/// </summary>
public abstract class ObjMoveByStaticPointLoop : ObjMovement
{
    [Header("ObjMoveByStaticPointLoop")]
    [SerializeField] protected float distanceToReset; // Distance threshold to trigger motion reset. Can be closest distance or can be farthest distance

    protected override void Moving(){
        base.Moving();

        ResetMovingAfterReachTarget();
    }

    protected void ResetMovingAfterReachTarget(){
        if(CanResetMoving()) ResetingMoving();
    }

    /// <summary>
    /// Checks if the object should reset its movement.
    /// </summary>
    protected virtual bool CanResetMoving(){
        // Check if the object is within the specified reset distance from the target position
        return Vector3.Distance(this.transform.parent.position, targetPosition) < distanceToReset;
    }

    /// <summary>
    /// Defining custom reset behavior when the object reaches the target distance.
    /// </summary>
    protected abstract void ResetingMoving();
}