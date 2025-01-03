using UnityEngine;

/// <summary>
/// Derived class extending ObjMovement allows objects to move object follow to target.
/// </summary>
public abstract class ObjMoveByTargetTransform : ObjMovement
{
    [Header("ObjMoveByTargetTransform")]
    protected Transform targetTransform;

    /// <summary>
    /// Set target to move forward.
    /// </summary>
    /// <param name="targetTransform">target to move forward.</param>
    public virtual void SetTargetTransform(Transform targetTransform)
    {
        this.targetTransform = targetTransform;
    }

    // Set targetPos base on moveTarget
    protected override void UpdateTargetPosition()
    {
        if (targetTransform == null) return;

        targetPosition = targetTransform.position;
    }
}