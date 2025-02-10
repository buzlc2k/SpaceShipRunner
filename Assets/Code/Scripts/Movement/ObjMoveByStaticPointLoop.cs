using System.Collections;
using UnityEngine;

/// <summary>
/// Abstract class for objects that move between static points in a loop with customizable behavior.
/// </summary>
public abstract class ObjMoveByStaticPointLoop : ObjMovement
{
    [Header("ObjMoveByStaticPointLoop")]
    protected Vector3 currentTargetPos;
    protected int remainingLoops; 
    protected ObjMoveByStaticPointLoopConfig objMoveByStaticPointLoopConfig;

    protected override void LoadValue()
    {
        base.LoadValue();
        
        currentTargetPos = objMoveByStaticPointLoopConfig.TargetPoint;
        remainingLoops = objMoveByStaticPointLoopConfig.RemainingLoops;
    }

    protected override void SetObjMovementConfig()
    {
        objMoveByStaticPointLoopConfig = (ObjMoveByStaticPointLoopConfig)objMovementConfig;
    }

    protected override void Moving()
    {
        base.Moving();

        ResetMoving();
    }

    /// <summary>
    /// Initializes a new movement loop with the specified number of iterations.
    /// </summary>
    /// <param name="_remainingLoops">The number of remaining loops (-1 for infinite loops).</param>
    public virtual void InitializeMovement(int _remainingLoops)
    {
        remainingLoops = _remainingLoops;
    }
    
    protected override void UpdateTargetPosition()
    {
        if (objMoveByStaticPointLoopConfig.MoveByLocalPoint) 
            targetPosition = transform.parent.parent.position + currentTargetPos;
        else 
            targetPosition = currentTargetPos;
    }

    #region ResetMovement
    
    // Handles resetting the object's movement when reaching the target.
    private void ResetMoving()
    {
        if (!CanResetMovement() || !CheckCanContinueLoop()) return;

        InitializeResetMoving();
    }

    // Checks if the object is close enough to the target position to reset.
    protected virtual bool CanResetMovement()
    {
        return Vector3.Distance(transform.parent.position, targetPosition) < objMoveByStaticPointLoopConfig.ResetDistanceThreshold;
    }

    // Checks if the object should continue looping and decrements the loop count if applicable.
    private bool CheckCanContinueLoop()
    {
        if (remainingLoops > 0) remainingLoops--;
        return remainingLoops != 0;
    }

    // Performs the reset behavior
    protected abstract void InitializeResetMoving();
    #endregion
}
