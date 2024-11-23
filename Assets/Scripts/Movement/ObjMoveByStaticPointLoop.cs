using System.Collections;
using UnityEngine;

/// <summary>
/// Abstract class for objects that move between static points in a loop with customizable behavior.
/// </summary>
public abstract class ObjMoveByStaticPointLoop : ObjMovement
{
    [Header("ObjMoveByStaticPointLoop")]
    [SerializeField] protected Vector3 spawnPoint;
    [SerializeField] protected Vector3 targetPoint;
    [SerializeField, Tooltip("-1 for infinite loops, 1 loop for 1/2 trajectory")] protected int remainingLoops = -1; 
    [SerializeField] protected float resetDistanceThreshold = 0.1f;
    [SerializeField, Tooltip("True if Object is moving based on parent position")] protected bool moveByLocalPoint;

    protected override void Moving()
    {
        UpdateTargetPosition();

        base.Moving();

        HandleResetMovement();
    }

    /// <summary>
    /// Initializes a new movement loop with the specified number of iterations.
    /// </summary>
    /// <param name="_remainingLoops">The number of remaining loops (-1 for infinite loops).</param>
    public virtual void InitializeMovement(int _remainingLoops)
    {
        remainingLoops = _remainingLoops;
    }

    #region UpdateTargetPos

    // Updates the target position based on local or world space.
    protected virtual void UpdateTargetPosition()
    {
        if (!ShouldUpdateTargetPosition()) return;

        targetPosition = CalculateTargetPosition();
    }

    private bool ShouldUpdateTargetPosition()
    {
        return moveByLocalPoint || !targetPoint.Equals(targetPosition);
    }

    private Vector3 CalculateTargetPosition()
    {
        return moveByLocalPoint
            ? transform.parent.parent.position + targetPoint
            : targetPoint;
    }
    #endregion

    #region ResetMovement
    
    // Handles resetting the object's movement when reaching the target.
    private void HandleResetMovement()
    {
        if (!CanResetMovement() || !CanContinueLoop()) return;

        PerformReseting();
    }

    // Checks if the object is close enough to the target position to reset.
    protected virtual bool CanResetMovement()
    {
        return Vector3.Distance(transform.parent.position, targetPosition) < resetDistanceThreshold;
    }

    // Checks if the object should continue looping and decrements the loop count if applicable.
    private bool CanContinueLoop()
    {
        if (remainingLoops > 0) remainingLoops--;
        return remainingLoops != 0;
    }

    // Performs the reset behavior
    protected abstract void PerformReseting();
    #endregion
}
