using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived class extending ObjMovement allows objects to reset their movement based on a specified distance from the target point.
/// </summary>
public abstract class ObjMoveByPointLoop : ObjMovement
{
    [Header("ObjMoveByPointLoop")]
    [SerializeField] protected float distanceToReset; // Distance threshold to trigger motion reset. Can be closest distance or can be farthest distance

    protected override void Moving(){
        base.Moving();

        ResetMovingAfterReachTarget();
    }

    /// <summary>
    /// Virtual method meant to be overridden to define how movement should reset once the target is reached.
    /// This method logs "Need override" if not overridden.
    /// </summary>
    protected virtual void ResetMovingAfterReachTarget(){
        Debug.Log("Need override");
    }
}