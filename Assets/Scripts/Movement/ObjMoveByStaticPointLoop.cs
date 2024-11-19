using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived class extending ObjMovement allows objects to reset their movement based on a custom logic.
/// </summary>
public abstract class ObjMoveByStaticPointLoop : ObjMovement
{
    [Header("ObjMoveByStaticPointLoop")]
    [SerializeField] protected Vector3 spawnPoint; 
    [SerializeField] protected Vector3 targetPoint; 
    [SerializeField] protected float distanceThreshold; 
    [SerializeField] protected bool moveByLocalPoint;

    protected override void Moving(){
        SetMovePosition();

        base.Moving();

        ResetMovingAfterReachTarget();
    }

    /// <summary>
    /// Updates the target position for the object to move to.
    /// If moveByLocalPoint is true, targetPosition is calculated from the parent's position and `argetPoint (as a local position).
    /// </summary>
    public virtual void SetMovePosition(){
        if(!moveByLocalPoint && targetPoint.Equals(targetPosition)) return;

        if(!moveByLocalPoint) targetPosition = targetPoint;
        else targetPosition = transform.parent.transform.parent.position + targetPoint;
    }

    protected void ResetMovingAfterReachTarget(){
        if(CanResetMoving()) ResetingMoving();
    }

    /// <summary>
    /// Checks if the object should reset its movement.
    /// </summary>
    protected virtual bool CanResetMoving(){
        // Check if the object is within the specified reset distance from the target position
        return Vector3.Distance(this.transform.parent.position, targetPosition) < distanceThreshold;
    }

    /// <summary>
    /// Defining custom reset behavior when the object reaches the target distance.
    /// </summary>
    protected abstract void ResetingMoving();
}